using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace GozalMusicMini
{
    public partial class MainForm : Form
	{
private AudioFileReader audioFileReader= null;
private DirectSoundOut waveOut = null;
        private Guid PlaybackDeviceID;
        private System.Timers.Timer switchTimer;

        private string accessToken;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            accessToken = "08ee901ce94ce05d8e5b79caff11022076956217af9ed6e4636b8dd9f57a98ef02161429cf8bcde0f03c1";
            switchTimer = new System.Timers.Timer();
            switchTimer.Interval = 1000;
            switchTimer.Elapsed += onSongFinished;
        }

        void onSongFinished(object sender, System.Timers.ElapsedEventArgs e)
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

        private void AudioSearch(string term)
        {
            WebRequest request = WebRequest.Create("https://api.vk.com/method/audio.search?q=" + term + "&count=300&access_token=" + accessToken + "&v=5.60");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close(); response.Close();
            responseFromServer = HttpUtility.HtmlDecode(responseFromServer);
            JToken token = JToken.Parse(responseFromServer);
            AudioList = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
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
            
        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
            Playfile();
    }

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

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
             progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!", "Success!");
        }
        
        private void TextBox1_KeyDown_1(object sender, KeyEventArgs e)
		{
            if (textBox1.Text != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        textBox1.SelectAll();
                        backgroundWorker1.RunWorkerAsync();
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

    private void Display()
    {
            if (AudioList.Count() == 0)
            {
                MessageBox.Show("Nothing found", "no results!");
            }
    listBox1.Items.Clear();
        foreach (var audio in AudioList)
        {
            string data = audio.Artist + " - " + audio.Title;
            data = data.TrimStart();
            int seconds = audio.Duration;
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

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AudioSearch(textBox1.Text);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Display();
        listBox1.Focus();
    }

    private void BackgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
    {
            Getpopular();
                }

    private void BackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Display();
            listBox1.Focus();
        }

    private void Button2_Click(object sender, EventArgs e)
    {
            //Getpopular();
            backgroundWorker3.RunWorkerAsync();
        }

    private void Getpopular()
    {
            WebRequest request = WebRequest.Create("https://api.vk.com/method/audio.getPopular?count=1000&access_token=" + accessToken + "&v=5.60");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close(); response.Close();
            responseFromServer = HttpUtility.HtmlDecode(responseFromServer);
            JToken token = JToken.Parse(responseFromServer);
            AudioList = token["response"].Children().Select(c => c.ToObject<Audio>()).ToList();
    }

    private void Play_Click(object sender, EventArgs e)
    {
        Playfile();
    }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                audioFileReader.Volume = trackBar1.Value / 100.0f;
            }
            catch (Exception)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
