using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GozalMusicMini
{
    public partial class MainForm : Form
    {
        private AudioFileReader audioFileReader = null;
        private DirectSoundOut waveOut = null;
        private Guid PlaybackDeviceID;
        private System.Timers.Timer switchTimer;

        private string accessToken;
        private int userID;
        private int count = 200;
        private string userAgent = "KateMobileAndroid/48.2 lite-433 (Android 8.1.0; SDK 27; arm64-v8a; Google Pixel 2 XL; en)";

            public List<Audio> AudioList;

        public class Audio
        {
            public int Aid { get; set; }
            public int Owner_id { get; set; }
            public string Artist { get; set; }
            public string Title { get; set; }
            public int Duration { get; set; }
            public string Url { get; set; }
            public string Lyrics_id { get; set; }
            public int Genre { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();
            InitialiseDeviceCombo();
            proxyMenuItem.Checked = Program.settings.use_proxy;
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            if (!Program.settings.auth)
            {
                new AuthForm().ShowDialog();
            }
            switchTimer = new System.Timers.Timer
            {
                Interval = 1000
            };
            switchTimer.Elapsed += OnSongFinished;
            accessToken = Program.settings.access_token;
            userID = Program.settings.user_id;
            string response = await MakeVKGetRequest($"users.get?user={userID}&access_token={accessToken}&v=5.70");
            JToken userInfo = JToken.Parse(response);
            this.Text = this.Text + userInfo["response"][0]["first_name"].ToString() + " - " + userInfo["response"][0]["last_name"].ToString();
        }

        void OnSongFinished(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (audioFileReader.CurrentTime.TotalMilliseconds > 0 && waveOut.PlaybackState == PlaybackState.Stopped)
            {
                listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                PlaySound(AudioList[listBox1.SelectedIndex].Url.ToString());
            }
        }

        private void InitialiseDeviceCombo()
        {
            comboBox1.DisplayMember = "Description";
            foreach (var device in DirectSoundOut.Devices)
            {
                comboBox1.Items.Add(device);
            }
            comboBox1.SelectedIndex = 0;
        }

        private async Task<string> MakeVKGetRequest(string method) {
            string apiBaseUrl;
            if (Program.settings.use_proxy)
            {
                apiBaseUrl = "https://vk-api-proxy.xtrafrancyz.net/method/";
            }
            else
            {
                apiBaseUrl = "https://api.vk.com/method/";
            }
                HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);
            HttpResponseMessage responseMessage = await client.GetAsync(apiBaseUrl + method);
            string content = await responseMessage.Content.ReadAsStringAsync();
            return content;
        }

            private async Task AudioSearchAsync(string term)
        {
            textBox1.Enabled = false;
            string response = await MakeVKGetRequest($"audio.search?q={term}&count={count}&access_token={accessToken}&v=5.70");
            JToken token = JToken.Parse(response);
            AudioList = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
            textBox1.Enabled = true;
        }

            private async Task AudioGetAsync(int ownerid)
        {
            string response = await MakeVKGetRequest($"audio.get?owner_id={ownerid}&count=1000&access_token={accessToken}&v=5.70");
            JToken token = JToken.Parse(response);
            AudioList = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
        }

        private async Task GetpopularAsync()
        {
            button2.Enabled = false;
            string response = await MakeVKGetRequest($"audio.getPopular?count=1000&access_token={accessToken}&v=5.70");
            JToken token = JToken.Parse(response);
            AudioList = token["response"].Children().Select(c => c.ToObject<Audio>()).ToList();
            button2.Enabled = true;
        }

        public void PlaySound(string filename)
        {
            CloseWaveOut();
            var devicesList = comboBox1.Items.Cast<DirectSoundDeviceInfo>().ToList();
            comboBox1.SelectedIndex = devicesList.FindIndex(device => device.Guid == ((DirectSoundDeviceInfo)comboBox1.SelectedItem).Guid);
            PlaybackDeviceID = ((DirectSoundDeviceInfo)comboBox1.SelectedItem).Guid;
            waveOut = new DirectSoundOut(PlaybackDeviceID);
            //waveOut.PlaybackStopped += AudioOutput_PlaybackStopped; this is naudio playback stopped event
            audioFileReader = new AudioFileReader(filename)
            {
                Volume = trackBar1.Value / 100.0f
            };
            waveOut.Init(audioFileReader);
            switchTimer.Start();
            waveOut.Play();
        }

        //void AudioOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        //{
                //listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                //PlaySound(AudioList[listBox1.SelectedIndex].Url.ToString());
            //}        

        private void CloseWaveOut()
        {
            if (waveOut == null) return;
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            if (audioFileReader == null) return;
                audioFileReader.Dispose();
                audioFileReader = null;
        }

        private void Playfile() 
        {
            try
            {
                PlaySound(AudioList[listBox1.SelectedIndex].Url.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot play track at this time" + ex.ToString(), "Error");
            }
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e) => Playfile();

        private void Download()
        {
            WebClient web = new WebClient();
            web.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            web.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            var dialog = new SaveFileDialog()
            {
                Filter = "Audio (*.mp3)|*.mp3",
                FileName = AudioList[listBox1.SelectedIndex].Artist + " - " + AudioList[listBox1.SelectedIndex].Title,
                RestoreDirectory = true,
                AddExtension = true
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                web.DownloadFileAsync(new Uri(@AudioList[listBox1.SelectedIndex].Url.ToString()), dialog.FileName);
            }
                    if (web != null)
                    {
                        web.Dispose();
                    }
                }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) => progressBar1.Value = e.ProgressPercentage;

        private void Completed(object sender, AsyncCompletedEventArgs e) => MessageBox.Show("Download completed!", "Success!");

        private async void TextBox1_KeyDown_1Async(object sender, KeyEventArgs e)
		{
            if (textBox1.Text != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        textBox1.SelectAll();
                        await AudioSearchAsync(textBox1.Text);
                        await Display();
                        listBox1.Focus();
                        break;
                }
            }
            }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
       {
           case Keys.Control | Keys.Down:
               try
               {
                        trackBar1.Value -= 1;
                        return true;
               }
               catch (Exception ex) when(ex is NullReferenceException || ex is ArgumentOutOfRangeException)
               {
                   return true;
               }
           case Keys.Control | Keys.Up:
               try
               {
                        trackBar1.Value += 1;
                        return true;
               }
                    catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                    {
                        return true;
               }
           case Keys.Control | Keys.Right:
                    if (textBox1.Focused)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            audioFileReader.CurrentTime = audioFileReader.CurrentTime + TimeSpan.FromSeconds(3);
                            return true;
                        }
                        catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                        {
                            return true;
                        }
                    }
           case Keys.Control | Keys.Left:
                    if (textBox1.Focused)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            audioFileReader.CurrentTime = audioFileReader.CurrentTime - TimeSpan.FromSeconds(3);
                            return true;
                        }
                        catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                        {
                            return true;
                        }
                    }
           case Keys.Control | Keys.Shift | Keys.Alt | Keys.Return:
               Download();
                return true;
                }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ListBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
    case Keys.Enter:
Playfile();
break;
                case Keys.Space:
                case Keys.MediaPlayPause:
                    if (waveOut != null)
                    {
                        if (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            waveOut.Pause();
                        }
                        else
                        {
                            waveOut.Play();
                        }
                    }
                        break;
}
        }

    private void TrackBar1_Scroll_1(object sender, EventArgs e)
    {
        try
        {
            audioFileReader.Volume = trackBar1.Value / 100.0f;
        }
        catch (Exception)
            {
        }
    }
 
    private void TrackBar2_Scroll(object sender, EventArgs e)
    {
            if (waveOut != null)
            {
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * trackBar2.Value / 100.0);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Dispose();
                var devicesList = comboBox1.Items.Cast<DirectSoundDeviceInfo>().ToList();
                comboBox1.SelectedIndex = devicesList.FindIndex(device => device.Guid == ((DirectSoundDeviceInfo)comboBox1.SelectedItem).Guid);
                PlaybackDeviceID = ((DirectSoundDeviceInfo)comboBox1.SelectedItem).Guid;
                waveOut = new DirectSoundOut(PlaybackDeviceID);
                //waveOut.PlaybackStopped += AudioOutput_PlaybackStopped;
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
            switchTimer.Stop();
            switchTimer.Dispose();
            CloseWaveOut();
    }

    private async Task Display()
    {
            if (AudioList.Count() == 0)
            {
                MessageBox.Show("Nothing found", "no results!");
            }
    listBox1.Items.Clear();
            for (int i = AudioList.Count -1; i >= 0; i--)
            {
                if (AudioList[i].Url == string.Empty)
                {
                    AudioList.RemoveAt(i);
                }
            }

            for (int i = 0; i < AudioList.Count; i++)
            {
                string data = AudioList[i].Artist + " - " + AudioList[i].Title;
            data = data.TrimStart();
            int seconds = AudioList[i].Duration;
            var timespan = TimeSpan.FromSeconds(seconds);
            listBox1.Items.Add(data + " " + timespan.ToString(@"mm\:ss"));
           //listBox1.Items.Add(new ListBoxItem("name", "value"));
        }
        
        listBox1.AccessibleName = listBox1.Items.Count + "Results found";
        try
        {
            listBox1.SetSelected(0, true);
        }
catch (ArgumentOutOfRangeException)
        {            
    }            
}

    private void Button1_Click(object sender, EventArgs e)
    {
            }

    private async void Button2_ClickAsync(object sender, EventArgs e)
    {
            await GetpopularAsync();
            await Display();
            listBox1.Focus();
        }

        private void Play_Click(object sender, EventArgs e) => Playfile();

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                audioFileReader.Volume = trackBar1.Value / 100.0f;
            }
            catch (Exception)
            {
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
                if (waveOut != null && audioFileReader != null)
                {
                TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
                trackBar2.Value = Math.Min(trackBar2.Maximum, (int)(100 * currentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds));
            }
            else
            {
                trackBar2.Value = 0;
            }
        }

        private void ProxyMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program.settings.use_proxy)
            {
                Program.settings.use_proxy = true;
                proxyMenuItem.Checked = true;
            }
            else
            {
                Program.settings.use_proxy = false;
                proxyMenuItem.Checked = false;
            }
            Program.settings.Save();
        }

            private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void TabControl1_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2) {
                await AudioGetAsync(userID);
                await Display();
                listBox1.Focus();
            }
            }
    }
}
