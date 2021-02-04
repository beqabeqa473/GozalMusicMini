using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;

namespace GozalMusicMini
{
    public partial class MainForm : Form
    {
        public string accessToken;
        private int userID;
private int deviceIndex;
        private bool proxy;
        private int index;
        private IniFile settings;
        private bool minimizedToTray;
        private int stream;
        private SYNCPROC syncCallback;

        public List<Audio> AudioList;
        public List<Audio> MyAudios;
        public List<Album> Albums;

        public string FullName { get; set; }

        public MainForm()
        {
            InitializeComponent();
            BassNet.Registration("beqaprogger@gmail.com", "2X11233721152222");
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            InitialiseDeviceCombo();
            lvAudios.Columns.Add("Исполнитель");
            lvAudios.Columns.Add("Название");
            lvAudios.Columns.Add("Длительность");
            settings = new IniFile();
            if (!settings.KeyExists("Proxy"))
            {
                settings.Write("Proxy", "false");
            }
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
            accessToken = settings.Read("Token");
            userID = Int32.Parse(settings.Read("UserID"));
            proxy = bool.Parse(settings.Read("Proxy"));
            var values = new Dictionary<string, string>
{
{"method", "flname"},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            JToken userInfo = JToken.Parse(response);
            FullName = userInfo["response"][0]["first_name"].ToString() + " " + userInfo["response"][0]["last_name"].ToString();
            this.Text = this.Text + " - " + FullName;
            mbFileProxy.Checked = proxy;
            await AudioGetAlbumsAsync();
            await AudioGetAsync();
            InitializeTreeview();
        }

        private void OnSongFinished(int handle, int channel, int data, IntPtr user)
        {
            lvAudios.Items[lvAudios.SelectedIndices[0] + 1].Focused = true;
            lvAudios.Items[lvAudios.SelectedIndices[0] + 1].Selected = true;
                if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
                {
                    index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
                    PlaySound(MyAudios[index].Url.ToString());
                }
                else
                {
                    PlaySound(AudioList[lvAudios.SelectedIndices[0]].Url.ToString());
                }
        }

        private void InitialiseDeviceCombo()
        {
int defaultDevice = Bass.BASS_GetDevice();
            for (int deviceId = 1; deviceId < Bass.BASS_GetDeviceCount(); deviceId++)
            {
                BASS_DEVICEINFO device = Bass.BASS_GetDeviceInfo(deviceId);
            cbDevices.Items.Add(device.name);
            }
            cbDevices.SelectedIndex = defaultDevice - 1;
        }

        private void InitializeTreeview()
        {
            TreeNode searchNode = new TreeNode("Поиск");
            tvSections.Nodes.Add(searchNode);
            TreeNode myAudiosNode = new TreeNode("Мое аудио")
            {
                ContextMenuStrip = cmSections
            };
            tvSections.Nodes.Add(myAudiosNode);
            TreeNode popularNode = new TreeNode("Популярное");
            tvSections.Nodes.Add(popularNode);
            TreeNode recommendationsNode = new TreeNode("Рекомендации");
            tvSections.Nodes.Add(recommendationsNode);
            tvSections.SelectedNode = searchNode;
            if (Albums.Count == 0)
            {
                return;
            }
            else
            {
                TreeNode albumNode;
                foreach (var album in Albums)
                {
                    albumNode = new TreeNode(album.Title)
                    {
                        ContextMenuStrip = cmSections,
                        Tag = album.id
                    };
                    myAudiosNode.Nodes.Add(albumNode);
                }
                albumNode = new TreeNode("Non album items")
                {
                    ContextMenuStrip = cmSections
                };
                myAudiosNode.Nodes.Add(albumNode);
            }
        }

        public async Task<string> MakeVKGetRequest(Dictionary<string, string> data)
        {
            string apiBaseUrl = "";
            if (proxy)
            {
                apiBaseUrl = "https://gozaltech.org/api_proxy/";
            }
            else
            {
                apiBaseUrl = "https://gozaltech.org/api/";
            }
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
            lvAudios.Focus();
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
            MyAudios = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
        }

        private async Task AudioAddAlbumAsync(string title)
        {
            var values = new Dictionary<string, string>
{
{"method", "audioaddalbum"},
{"title", title},
{"owner_id", userID.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            if (response.Contains("response"))
            {
                JObject obj = JObject.Parse(response);
                JToken root = obj["response"];
                var albumItem = JsonConvert.DeserializeObject<Album>(root.ToString());
                Albums.Insert(0, albumItem);
                TreeNode albumNode = new TreeNode(Albums[0].Title)
                {
                    ContextMenuStrip = cmSections,
                    Tag = Albums[0].id
                };
                tvSections.Nodes[1].Nodes.Insert(0, albumNode);
            }
        }

            private async Task<bool> AudioDeleteAlbumAsync(int albumId)
        {
                var values = new Dictionary<string, string>
{
{"method", "audiodeletealbum"},
{"playlist_id", albumId.ToString()},
{"owner_id", userID.ToString()},
{"access_token", accessToken}
};
                string response = await MakeVKGetRequest(values);
                if (response.Contains("response"))
                {
                return true;
                }
                else
                {
                return false;
            }
        }

        private async Task<bool> AudioEditAlbumAsync(string title, int albumID)
        {
            var values = new Dictionary<string, string>
{
{"method", "audioeditalbum"},
{"title", title},
{"playlist_id", albumID.ToString()},
{"owner_id", userID.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            if (response.Contains("response"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            private async Task AudioGetAlbumsAsync()
        {
            var values = new Dictionary<string, string>
{
{"method", "audiogetalbums"},
{"owner_id", userID.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            JToken token = JToken.Parse(response);
            Albums = token["response"]["items"].Children().Select(c => c.ToObject<Album>()).ToList();
        }

            private async Task GetpopularAsync()
        {
            btnPopular.Enabled = false;
            var values = new Dictionary<string, string>
{
{"method", "audiopopular"},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            JToken token = JToken.Parse(response);
            AudioList = token["response"].Children().Select(c => c.ToObject<Audio>()).ToList();
            Display();
            lvAudios.Focus();
            btnPopular.Enabled = true;
        }

        private async Task GetRecommendationsAsync(string targetAudios = null, string userId = null)
        {
            var values = new Dictionary<string, string>
{
{"method", "audiogetrecommendations"},
{"access_token", accessToken}
};
            if (targetAudios != null)
            {
                values.Add("target_audios", targetAudios);
            }
            if (userId != null)
            {
                values.Add("user_id", userId);
            }
            string response = await MakeVKGetRequest(values);
            JToken token = JToken.Parse(response);
            AudioList = token["response"]["items"].Children().Select(c => c.ToObject<Audio>()).ToList();
            Display();
            lvAudios.Focus();
        }

        private async Task<bool> AudioAddAsync(int aId, int oId)
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
                return true;
            }
            else
            {
                return false;
            }
            }

        private async Task<bool> AudioDeleteAsync(int aId, int oId)
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
                return true;
                }
                else
                {
                return false;
            }
            }

        private async Task<bool> AudioRestoreAsync(int aId, int oId)
        {
            var values = new Dictionary<string, string>
{
{"method", "audiorestore"},
{"audio_id", aId.ToString()},
{"owner_id", oId.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            if (response.Contains("response"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void AudioEditAsync()
        {
            index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
            var values = new Dictionary<string, string>
{
{"method", "audiogetlyrics"},
{"lyrics_id", MyAudios[index].Lyrics_id.ToString()},
{"access_token", accessToken}
};
            string response = await MakeVKGetRequest(values);
            EditAudio audioeditfrm = new EditAudio
            {
                Ownerid = MyAudios[index].Owner_id,
                Id = MyAudios[index].id,
                Artist = MyAudios[index].Artist,
                Title = MyAudios[index].Title,
                Genre_id = MyAudios[index].Genre_id
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
            Bass.BASS_StreamFree(stream);
            syncCallback = new SYNCPROC(OnSongFinished);
            BASSActive isActive = default(BASSActive);
            isActive = Bass.BASS_ChannelIsActive(stream);
            if (isActive == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelStop(stream);
            }
            filename = Regex.Replace(filename, @"/[a-zA-Z\d]{6,}(/.*?[a-zA-Z\d]+?)/index.m3u8()", @"$1$2.mp3");
            stream = Bass.BASS_StreamCreateURL(filename, 0, 0, null, IntPtr.Zero);
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, tbVolume.Value / 100F);
            Bass.BASS_ChannelSetSync(stream, BASSSync.BASS_SYNC_END, 0, syncCallback, IntPtr.Zero);
            //Bass.BASS_Init(deviceIndex, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            Bass.BASS_SetDevice(deviceIndex);
            Bass.BASS_ChannelSetDevice(stream, deviceIndex);
            Bass.BASS_ChannelPlay(stream, false);
        }

        //void AudioOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        //{
        //lvAudios.SetSelected(lvAudios.SelectedIndex + 1, true);
        //PlaySound(AudioList[lvAudios.SelectedIndex].Url.ToString());
        //}        

        private void Playfile() 
        {
            try
            {
                if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
                {
                    index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
                    PlaySound(MyAudios[index].Url.ToString());
                }
                else
                {
                    PlaySound(AudioList[lvAudios.SelectedIndices[0]].Url.ToString());
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось возпроизвести трек" + ex.ToString(), "Ошибка");
            }
        }

        private void LvAudios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Playfile();
        }

        private void DownloadSingle()
        {
            string fName, fUrl;
            if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
            {
                index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
                fName = MyAudios[index].Artist + " - " + MyAudios[index].Title;
fUrl = MyAudios[index].Url;
            }
            else
            {
                fName = AudioList[lvAudios.SelectedIndices[0]].Artist + " - " + AudioList[lvAudios.SelectedIndices[0]].Title;
fUrl = AudioList[lvAudios.SelectedIndices[0]].Url;
            }
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
                    webClient.DownloadFileAsync(new Uri(Regex.Replace(fUrl, @"/[a-zA-Z\d]{6,}(/.*?[a-zA-Z\d]+?)/index.m3u8()", @"$1$2.mp3")), dialog.FileName);
                }
                }
                }

        private async Task DownloadMultipleAsync()
        {
            string fName, fUrl;
            var dialog = new FolderBrowserDialog()
            {
                Description = "Выберите директорию для сохранения треков",
                ShowNewFolderButton = true
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    foreach (ListViewItem item in lvAudios.CheckedItems)
                    {
                        if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
                        {
                            index = MyAudios.FindIndex(x => x.id == (int)item.Tag);
                            fName = MyAudios[index].Artist + " - " + MyAudios[index].Title + ".mp3";
fUrl = MyAudios[index].Url;
                        }
                        else
                        {
                            fName = AudioList[item.Index].Artist + " - " + AudioList[item.Index].Title + ".mp3";
                            fUrl = AudioList[item.Index].Url;
                        }
                        webClient.QueryString.Add("file", fName);
                        await webClient.DownloadFileTaskAsync(Regex.Replace(fUrl, @"/[a-zA-Z\d]{6,}(/.*?[a-zA-Z\d]+?)/index.m3u8()", @"$1$2.mp3"), dialog.SelectedPath  + @"\" + fName);
                    }
                }
                }
            }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbDownload.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string fName = ((WebClient)(sender)).QueryString["file"];
            niTray.Visible = true;
            niTray.ShowBalloonTip(5000, "Успешно", $"Файл {fName} Успешно скачан", ToolTipIcon.Info);
            niTray.Visible = false;
        }

        private async void TxtSearch_KeyDown_1Async(object sender, KeyEventArgs e)
		{
            if (txtSearch.Text != null && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        txtSearch.SelectAll();
                        await AudioSearchAsync(txtSearch.Text);
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
                        tbVolume.Value -= 1;
                        return true;
                    }
                    catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                    {
                        return true;
                    }
                case Keys.Control | Keys.Up:
                    try
                    {
                        tbVolume.Value += 1;
                        return true;
                    }
                    catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                    {
                        return true;
                    }
                case Keys.Control | Keys.Right:
                    if (txtSearch.Focused)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            double length = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
                            double curPos = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream));
                            Bass.BASS_ChannelSetPosition(stream, curPos + Convert.ToDouble(2));
                            return true;
                        }
                        catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                        {
                            return true;
                        }
                    }
                case Keys.Control | Keys.Left:
                    if (txtSearch.Focused)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            double curPos = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream));
                            Bass.BASS_ChannelSetPosition(stream, curPos - Convert.ToDouble(2));
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

        private void LvAudios_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    Playfile();
                    break;
                case Keys.Shift | Keys.Enter:
                    if (lvAudios.SelectedItems.Count == 0)
                        return;
                    if (tvSections.SelectedNode != tvSections.Nodes[1] && tvSections.SelectedNode.Parent != tvSections.Nodes[1])
                    {
                        cmAudiosAdd.PerformClick();
                    }
                    break;
                case Keys.Delete:
                    if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
                    {
                        cmAudiosDelete.PerformClick();
                    }
                    break;
                case Keys.Control | Keys.Shift | Keys.Alt | Keys.Return:
                    cmAudiosDownload.PerformClick();
                    break;
                case Keys.F2:
                    if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
                    {
                        AudioEditAsync();
                    }
                    break;
                case Keys.Space:
                case Keys.MediaPlayPause:
                    BASSActive isActive = default(BASSActive);
                    isActive = Bass.BASS_ChannelIsActive(stream);
                    if (isActive == BASSActive.BASS_ACTIVE_PLAYING)
                    {
                        Bass.BASS_ChannelPause(stream);
                    }
                    else if (isActive == BASSActive.BASS_ACTIVE_PAUSED)
                    {
                        Bass.BASS_ChannelPlay(stream, false);
                    }
                        e.Handled = e.SuppressKeyPress = true;
                    break;
            }
        }

        private void TbVolume_Scroll(object sender, EventArgs e)
    {
        try
        {
                Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, tbVolume.Value / 100F);
            }
        catch (Exception)
            {
        }
    }
 
    private void TbSeek_Scroll(object sender, EventArgs e)
    {
            double length = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
            Bass.BASS_ChannelSetPosition(stream, length * tbSeek.Value / 100);
        }

        private void CbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            deviceIndex = cbDevices.SelectedIndex + 1;
            //int oldDevice = Bass.BASS_GetDevice();
            Bass.BASS_Init(deviceIndex, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            Bass.BASS_SetDevice(deviceIndex);
            Bass.BASS_ChannelSetDevice(stream, deviceIndex);
            //Bass.BASS_Free();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
            Bass.BASS_StreamFree(stream);
            Bass.BASS_Free();
        }

        private void Display()
    {
            if (AudioList.Count() == 0)
            {
                MessageBox.Show("Ничего не найдено", "Нет результатов");
            }
    lvAudios.Items.Clear();
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
                lvAudios.Items.Add(item);
        }
        
        lvAudios.AccessibleName = lvAudios.Items.Count + "Results found";
        try
        {
                lvAudios.Items[0].Selected = true;
        }
catch (ArgumentOutOfRangeException)
        {            
    }            
}

        private void FillMyAudios(int albumID)
        {
            if (MyAudios.Count() == 0)
                return;
            IEnumerable<Audio> audios;
            lvAudios.Items.Clear();
            for (int i = MyAudios.Count - 1; i >= 0; i--)
            {
                if (MyAudios[i].Url == string.Empty)
                {
                    MyAudios.RemoveAt(i);
                }
            }

            if (albumID == -1)
            {
                audios = MyAudios;
            }
            else if (albumID == 0)
            {
                audios = MyAudios.Where(x => x.Album_id == 0);
            }
            else
            {
                audios = MyAudios.Where(x => x.Album_id == albumID);
            }
            foreach (var audio in audios)
            {
                int seconds = audio.Duration;
                var timespan = TimeSpan.FromSeconds(seconds);
                ListViewItem item = new ListViewItem();
                item.Text = audio.Artist.Trim();
                item.SubItems.Add(audio.Title.Trim());
                item.SubItems.Add(timespan.ToString(@"mm\:ss"));
                item.Tag = audio.id;
                lvAudios.Items.Add(item);
            }

            lvAudios.AccessibleName = lvAudios.Items.Count + "Results found";
            try
            {
                lvAudios.Items[0].Selected = true;
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private async void BtnPopular_ClickAsync(object sender, EventArgs e)
        {
            await GetpopularAsync();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Playfile();
        }   


        private void TbVolume_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Bass.BASS_ChannelSetAttribute(stream, Un4seen.Bass.BASSAttribute.BASS_ATTRIB_VOL, tbVolume.Value / 100F);
            }
            catch (Exception)
            {
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            double len = Bass.BASS_ChannelGetLength(stream);
                double pos = Bass.BASS_ChannelGetPosition(stream);
            tbSeek.Value = Math.Min(tbSeek.Maximum, (int)(100 * pos / len));
        }

            private void MbFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult dialogResult = MessageBox.Show("Желаете свернуть программу в системный трей?", "Свернуть окно", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Hide();
                    this.niTray.Visible = true;
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
                this.niTray.Visible = false;
                minimizedToTray = false;
            }
            else
            {
                WinApi.ShowToFront(this.Handle);
            }
            }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowWindow();
            }
            }

        private async void TvSections_AfterSelectAsync(object sender, TreeViewEventArgs e)
        {
            lvAudios.Items.Clear();
            lvAudios.AccessibleName = null; 
            txtSearch.Clear();
                cmAudiosAdd.Visible = !tvSections.Nodes[1].IsSelected && tvSections.SelectedNode.Parent == null;
            cmAudiosRecomsAudio.Visible = !tvSections.Nodes[1].IsSelected && tvSections.SelectedNode.Parent == null;
            cmAudiosRecomsOwner.Visible = !tvSections.Nodes[1].IsSelected && tvSections.SelectedNode.Parent == null;
            cmAudiosEdit.Visible = tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1];
                cmAudiosDelete.Visible = tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1];
                cmSectionsDelete.Visible = tvSections.SelectedNode.Parent == tvSections.Nodes[1] && tvSections.SelectedNode.Text != "Non album items";
                cmSectionsEdit.Visible = tvSections.SelectedNode.Parent == tvSections.Nodes[1] && tvSections.SelectedNode.Text != "Non album items";
            lbSearch.Visible = tvSections.Nodes[0].IsSelected;
            txtSearch.Visible = tvSections.Nodes[0].IsSelected;
            btnPopular.Visible = tvSections.Nodes[2].IsSelected;
            if (e.Node == tvSections.Nodes[1])
            {
                FillMyAudios(-1);
            }
            else if (e.Node.Parent != null && e.Node.Text == "Non album items")
            {
                FillMyAudios(0);
            }
            else if (e.Node.Parent != null && e.Node.Text == Albums[e.Node.Index].Title)
            {
                FillMyAudios(Albums[tvSections.SelectedNode.Index].id);
            }
            else if (e.Node == tvSections.Nodes[3])
            {
                await GetRecommendationsAsync(null, userID.ToString());
            }
        }

        private async void Add_ClickAsync(object sender, EventArgs e)
        {
            if (await AudioAddAsync(AudioList[lvAudios.SelectedIndices[0]].id, AudioList[lvAudios.SelectedIndices[0]].Owner_id))
            {
                await AudioGetAsync();
                MessageBox.Show("Аудио запись добавлена в вашу библиотеку", "Успешно");
            }
            else
            {
                MessageBox.Show("Не удалось добавить аудио запись в вашу библиотеку", "Ошибка");
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            AudioEditAsync();
        }

        private async void Delete_ClickAsync(object sender, EventArgs e)
        {
            index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
                DialogResult dialogResult = MessageBox.Show($"Желаете удалить {MyAudios[index].Title} из вашей библиотеки? Примечание, вы сможете востановить данную аудио запись в течении следующих 20 минут.", "Delete audio", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (await AudioDeleteAsync(MyAudios[index].id, MyAudios[index].Owner_id))
                    {
                        MyAudios[index].Deleted = true;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить аудио запись из вашей библиотеки", "Ошибка");
                    }
                }
            }

                    private async void AddAlbum_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox.Show("Добавить альбом", "Введите название альбома", ref value) == DialogResult.OK)
            {
                await AudioAddAlbumAsync(value);
            }
        }

        private async void EditAlbum_Click(object sender, EventArgs e)
        {
            index = Albums.FindIndex(x => x.id == (int)tvSections.SelectedNode.Tag);
            string value = Albums[index].Title;
            if (InputBox.Show("Редактировать альбом", "Введите новое название для альбома", ref value) == DialogResult.OK)
            {
                if (await AudioEditAlbumAsync(value, Albums[index].id))
                {
                    Albums[index].Title = value;
                    tvSections.Nodes[1].Nodes[index].Text = value;
                }
                }
        }

        private async void DeleteAlbum_Click(object sender, EventArgs e)
        {
            index = Albums.FindIndex(x => x.id == (int)tvSections.SelectedNode.Tag);
            DialogResult dialogResult = MessageBox.Show($"Желаете удалить {Albums[index].Title}?", "Удалить альбом", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (await AudioDeleteAlbumAsync(Albums[index].id))
                {
                    Albums.RemoveAt(index);
                    tvSections.Nodes[1].Nodes.RemoveAt(tvSections.SelectedNode.Index);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить альбом", "Ошибка");
                }
            }
            }

        private void ReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this);
            report.Show();
        }

        private void TvSections_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete:
                    if (tvSections.SelectedNode.Parent == tvSections.Nodes[1] && tvSections.SelectedNode.Text != "Non album items") {
                        cmSectionsDelete.PerformClick();
            }
            break;
                case Keys.F2:
            if (tvSections.SelectedNode.Parent == tvSections.Nodes[1] && tvSections.SelectedNode.Text != "Non album items") {
                cmSectionsEdit.PerformClick();
        }
            break;
            }
            }

        private void LvAudios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAudios.SelectedItems.Count == 0)
                return;
            if (tvSections.SelectedNode == tvSections.Nodes[1] || tvSections.SelectedNode.Parent == tvSections.Nodes[1])
            {
                index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
                if (MyAudios[index].Deleted)
                {
                    cmAudiosDelete.Visible = false;
                    cmAudiosRestore.Visible = true;
                    Console.Beep();
                }
                else
                {
                    cmAudiosDelete.Visible = true;
                    cmAudiosRestore.Visible = false;
                }
            }
                }

        private void mbFileProxy_Click(object sender, EventArgs e)
        {
                        if (!mbFileProxy.Checked)
                            {
                settings.Write("Proxy", "true");
                mbFileProxy.Checked = true;
                proxy = true;
            }
                        else
            {
                settings.Write("Proxy", "false");
                mbFileProxy.Checked = false;
                proxy = false;
            }
        }

        private async void cmAudiosRestore_ClickAsync(object sender, EventArgs e)
        {
            index = MyAudios.FindIndex(x => x.id == (int)lvAudios.SelectedItems[0].Tag);
            DialogResult dialogResult = MessageBox.Show($"Желаете востановить {MyAudios[index].Title}?", "Востановить аудио запись", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (await AudioRestoreAsync(MyAudios[index].id, MyAudios[index].Owner_id))
                {
                    MyAudios[index].Deleted = false;
                }
                else
                {
                    MessageBox.Show("Не удалось востановить аудио запись. скорее всего истекло время.", "Ошибка");
                    MyAudios.RemoveAt(index);
                    lvAudios.Items.RemoveAt(lvAudios.SelectedIndices[0]);
                }
            }
        }

        private async void cmAudiosDownload_ClickAsync(object sender, EventArgs e)
        {
            if (lvAudios.CheckedItems.Count > 1)
            {
                await DownloadMultipleAsync();
            }
            else
            {
                DownloadSingle();
            }
        }

        private async void cmAudiosRecomsAudio_ClickAsync(object sender, EventArgs e)
        {
                await GetRecommendationsAsync(AudioList[lvAudios.SelectedIndices[0]].id.ToString() + "_" + AudioList[lvAudios.SelectedIndices[0]].Owner_id.ToString(), null);
            }

        private async void cmAudiosRecomsOwner_ClickAsync(object sender, EventArgs e)
        {
                await GetRecommendationsAsync(null, AudioList[lvAudios.SelectedIndices[0]].Owner_id.ToString());
            }


    }
}
