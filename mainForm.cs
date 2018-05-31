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

        public string accessToken;
        private int userID;
        IniFile settings;
        bool minimizedToTray;

        public List<Audio> AudioList;

                        public MainForm()
        {
            InitializeComponent();
            string[] treeNodes = new string[3];
            treeNodes[0] = "Search";
            treeNodes[1] = "My audios";
            treeNodes[2] = "Popular";
            foreach (string snode in treeNodes)
            {
                TreeNode node = new TreeNode(snode);
                treeView1.Nodes.Add(node);
            }
            InitialiseDeviceCombo();
            listView1.Columns.Add("Artist");
            listView1.Columns.Add("Title");
            listView1.Columns.Add("Duration");
            settings = new IniFile();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                ShowWindow();
            }
            base.WndProc(ref m);
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            switchTimer = new System.Timers.Timer
            {
                Interval = 1000
            };
            switchTimer.Elapsed += OnSongFinished;
            accessToken = settings.Read("Token");
            userID = Int32.Parse(settings.Read("UserID"));
            var values = new Dictionary<string, string>
{
{"method", "flname"},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            JToken userInfo = JToken.Parse(response);
            this.Text = this.Text + userInfo["response"][0]["first_name"].ToString() + " - " + userInfo["response"][0]["last_name"].ToString();
        }

        void OnSongFinished(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (audioFileReader.CurrentTime.TotalMilliseconds > 0 && waveOut.PlaybackState == PlaybackState.Stopped)
            {
                listView1.Items[listView1.SelectedIndices[0] + 1].Selected = true;
                PlaySound(AudioList[listView1.SelectedIndices[0]].Url.ToString());
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

        public async Task<string> MakeVKGetRequest(Dictionary<string, string> data)
        {
            string apiBaseUrl = "https://gozaltech.org/api/";
                HttpClient client = new HttpClient();
            var postData = new FormUrlEncodedContent(data);
            HttpResponseMessage responseMessage = await client.PostAsync(apiBaseUrl, postData);
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            return responseBody;
        }

        private async Task AudioSearchAsync(string term)
        {
            var values = new Dictionary<string, string>
{
{"method", "audiosearch"},
{"access_token", accessToken},
{"query", term}
};
            string response = await MakeVKGetRequest(values);
            JToken token = JToken.Parse(response);
            AudioList = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
            Display();
            listView1.Focus();
        }

        private async Task AudioGetAsync()
        {
            var values = new Dictionary<string, string>
{
{"method", "audioget"},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            JToken token = JToken.Parse(response);
            AudioList = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
            Display();
            listView1.Focus();
        }

        private async Task GetpopularAsync()
        {
            button2.Enabled = false;
            var values = new Dictionary<string, string>
{
{"method", "audiopopular"},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            JToken token = JToken.Parse(response);
            AudioList = token["response"].Children().Select(c => c.ToObject<Audio>()).ToList();
            Display();
            listView1.Focus();
            button2.Enabled = true;
        }

        private async Task AudioAddAsync(int aId, int oId)
        {
            var values = new Dictionary<string, string>
{
{"method", "audioadd"},
{"audio_id", aId.ToString()},
{"owner_id", oId.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            if (response.Contains("response"))
            {
                MessageBox.Show("Added audio to your audio library", "Success");
            }
            else
            {
                MessageBox.Show("Could not dd audio to your audio library", "Error");
            }
            }

        private async Task AudioDeleteAsync(int aId, int oId)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + AudioList[listView1.SelectedIndices[0]].Title + "from your library?", "Delete audio", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var values = new Dictionary<string, string>
{
{"method", "audiodelete"},
{"audio_id", aId.ToString()},
{"owner_id", oId.ToString()},
{"access_token", accessToken}
};
                string response = await MakeVKGetRequest(values);
                if (response.Contains("response"))
                {
                    AudioList.RemoveAt(listView1.SelectedIndices[0]);
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    MessageBox.Show("Deleted audio from your audio library", "Success");
                }
                else
                {
                    MessageBox.Show("Could not delete audio from your audio library", "Error");
                }
            }
            }

        private async void AudioEditAsync()
        {
            var values = new Dictionary<string, string>
{
{"method", "audiogetlyrics"},
{"lyrics_id", AudioList[listView1.SelectedIndices[0]].Lyrics_id.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            EditAudio audioeditfrm = new EditAudio
            {
                Ownerid = AudioList[listView1.SelectedIndices[0]].Owner_id,
                Id = AudioList[listView1.SelectedIndices[0]].id,
                Artist = AudioList[listView1.SelectedIndices[0]].Artist,
                Title = AudioList[listView1.SelectedIndices[0]].Title,
                Genre_id = AudioList[listView1.SelectedIndices[0]].Genre_id
            };
            if (response.Contains("response"))
            {
                JToken lyrics = JToken.Parse(response);
                audioeditfrm.LyricsText = lyrics["response"]["text"].ToString(); ;
            }
            else
            {
                audioeditfrm.LyricsText = "No lyrics";
            }
            audioeditfrm.Show();
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
                //listView1.SetSelected(listView1.SelectedIndex + 1, true);
                //PlaySound(AudioList[listView1.SelectedIndex].Url.ToString());
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
                PlaySound(AudioList[listView1.SelectedIndices[0]].Url.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot play track at this time" + ex.ToString(), "Error");
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e) => Playfile();

        private void DownloadSingle()
        {
            string fName = AudioList[listView1.SelectedIndices[0]].Artist + " - " + AudioList[listView1.SelectedIndices[0]].Title;
            var dialog = new SaveFileDialog()
            {
                Filter = "Audio (*.mp3)|*.mp3",
                FileName = fName,
                RestoreDirectory = true,
                AddExtension = true
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.QueryString.Add("file", fName);
                    webClient.DownloadFileAsync(new Uri(@AudioList[listView1.SelectedIndices[0]].Url.ToString()), dialog.FileName);
                }
                }
                }

        private async Task DownloadMultipleAsync()
        {
            string fName = "";
            var dialog = new FolderBrowserDialog()
            {
                Description = "Select a directory to save selected tracks",
                ShowNewFolderButton = true
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.QueryString.Add("file", fName);
                    foreach (ListViewItem item in listView1.CheckedItems)
                    {
                        fName = AudioList[item.Index].Artist + " - " + AudioList[item.Index].Title + ".mp3";
                        await webClient.DownloadFileTaskAsync(AudioList[item.Index].Url, dialog.SelectedPath  + @"\" + fName);
                    }
                }
                }
            }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) => progressBar1.Value = e.ProgressPercentage;

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string fName = ((WebClient)(sender)).QueryString["file"];
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(5000, "Success", $"File {fName} has been successfully downloaded", ToolTipIcon.Info);
            trayIcon.Visible = false;
        }

        private async void TextBox1_KeyDown_1Async(object sender, KeyEventArgs e)
		{
            if (textBox1.Text != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        textBox1.SelectAll();
                        await AudioSearchAsync(textBox1.Text);
                        break;
                }
            }
            }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Down:
                    try
                    {
                        trackBar1.Value -= 1;
                        return true;
                    }
                    catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
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
                }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void ListView1_KeyDownAsync(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
    case Keys.Enter:
Playfile();
break;
                case Keys.Shift | Keys.Enter:
                    if (treeView1.SelectedNode.Text != "My audios")
                    {
                        await AudioAddAsync(AudioList[listView1.SelectedIndices[0]].id, AudioList[listView1.SelectedIndices[0]].Owner_id);
                    }
                        break;
                case Keys.Delete:
                    if (treeView1.SelectedNode.Text == "My audios")
                    {
                        await AudioDeleteAsync(AudioList[listView1.SelectedIndices[0]].id, AudioList[listView1.SelectedIndices[0]].Owner_id);
                    }
                        break;
                case Keys.Control | Keys.Shift | Keys.Alt | Keys.Return:
                    if (listView1.CheckedItems.Count > 1)
                    {
                        await DownloadMultipleAsync();
                    }
                    else
                    {
                        DownloadSingle();
                    }
                    break;
                case Keys.F2:
                    if (treeView1.SelectedNode.Text == "My audios")
                    {
                        AudioEditAsync();
                    }
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
                    e.Handled = e.SuppressKeyPress = true;
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
    listView1.Items.Clear();
            for (int i = AudioList.Count -1; i >= 0; i--)
            {
                if (AudioList[i].Url == string.Empty)
                {
                    AudioList.RemoveAt(i);
                }
            }

            for (int i = 0; i < AudioList.Count; i++)
            {
                int seconds = AudioList[i].Duration;
                var timespan = TimeSpan.FromSeconds(seconds);
                ListViewItem item = new ListViewItem();
                item.Text = AudioList[i].Artist.Trim();
                item.SubItems.Add(AudioList[i].Title.Trim());
                item.SubItems.Add(timespan.ToString(@"mm\:ss"));
                listView1.Items.Add(item);
        }
        
        listView1.AccessibleName = listView1.Items.Count + "Results found";
        try
        {
                listView1.Items[0].Selected = true;
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

            private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to hide window to system tray?", "Hide window", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Hide();
                    this.trayIcon.Visible = true;
                    minimizedToTray = true;
                }
            }
            }

        private void ShowWindow() {
            if (minimizedToTray)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();
                this.Activate();
                this.trayIcon.Visible = false;
                minimizedToTray = false;
            }
            else
            {
                WinApi.ShowToFront(this.Handle);
            }
            }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowWindow();
            }
            }

        private async void treeView1_AfterSelectAsync(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Search")
            {
                textBox1.Enabled = true;
                button2.Enabled = false;
            }
            else if (e.Node.Text == "My audios") {
                textBox1.Enabled = false;
                button2.Enabled = false;
                await AudioGetAsync();
            }
            else if (e.Node.Text == "Popular")
            {
                textBox1.Enabled = false;
                button2.Enabled = true;
            }
            }

        private async void Add_ClickAsync(object sender, EventArgs e)
        {
            await AudioAddAsync(AudioList[listView1.SelectedIndices[0]].id, AudioList[listView1.SelectedIndices[0]].Owner_id);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            AudioEditAsync();
        }

        private async void Delete_ClickAsync(object sender, EventArgs e)
        {
            await AudioDeleteAsync(AudioList[listView1.SelectedIndices[0]].id, AudioList[listView1.SelectedIndices[0]].Owner_id);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text != "My audios")
            {
                Add.Enabled = true;
            }
            else
            {
                Add.Enabled = false;
            }
            if (treeView1.SelectedNode.Text == "My audios")
            {
                Edit.Enabled = true;
                Delete.Enabled = true;
            }
            else
            {
                Edit.Enabled = false;
                Delete.Enabled = false;
            }
        }
    }
}
