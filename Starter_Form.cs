using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GozalMusicMini
{
    public partial class Starter_Form : Form
    {
        public bool IsLoggedIn { get; set; }
        private Update update;
        public Starter_Form()
        {
            InitializeComponent();
        }

        private async void Starter_Form_LoadAsync(object sender, System.EventArgs e)
        {
                await CheckForUpdatesAsync();
                var settings = new IniFile();
            if (!settings.KeyExists("Token"))
            {
                IsLoggedIn = false;
                Close();
            }
            else
            {
                string token = settings.Read("Token");
                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
{
{"method", "checkAuth"},
{"access_token", token}
};
                var content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = await client.PostAsync("https://gozaltech.org/api/", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody == "403")
                {
                    IsLoggedIn = false;
                    MessageBox.Show("Доступ запрещен", "Ошибка");
                    Application.Exit();
                }
                else if (responseBody == "401" || responseBody == "404")
                {
                    IsLoggedIn = false;
                    Close();
                }
                else
                {
                    IsLoggedIn = true;
                    Close();
                }
            }
        }

        private async Task CheckForUpdatesAsync()
            {
            MainForm mForm = new MainForm();
            var values = new Dictionary<string, string>
{
{"method", "checkupdate"}
};
                string response = await mForm.MakeVKGetRequest(values);
            update = JToken.Parse(response).ToObject<Update>();
                if (Version.Parse(Application.ProductVersion) < Version.Parse(update.Version))
                {
                    string value = update.Changes;
                    if (InputBox.Show("Доступно обновление", $"новая версия {update.Version} {Application.ProductName} доступна для скачивания. нажмите ok для скачивания и установки данного обновления, или отмену для последующей установки.", ref value, true, true) == DialogResult.OK)
                    {
                        System.IO.File.Move(AppDomain.CurrentDomain.FriendlyName, AppDomain.CurrentDomain.FriendlyName + ".back");
                        using (var wC = new WebClient())
                        {
                            wC.DownloadFileCompleted += new AsyncCompletedEventHandler(UpdateCompleted);
                            wC.DownloadProgressChanged += new DownloadProgressChangedEventHandler(UpdateProgressChanged);
                            await wC.DownloadFileTaskAsync(new Uri(update.Download), AppDomain.CurrentDomain.FriendlyName);
                        }
                    }
                }
        }

        private void UpdateProgressChanged(object sender, DownloadProgressChangedEventArgs e) => progressBar1.Value = e.ProgressPercentage;

            private void UpdateCompleted(object sender, AsyncCompletedEventArgs e)
            {
            if (GetMD5HashFromFile(AppDomain.CurrentDomain.FriendlyName) == update.CheckSum)
            {
                Application.Restart();
            }
            else
            {
                MessageBox.Show("контрольные суммы файлов не совпадают. будет возвращена старая версия. пожалуйста попробуйте еще раз.", "Ошибка");
                File.Delete(AppDomain.CurrentDomain.FriendlyName);
                File.Move(AppDomain.CurrentDomain.FriendlyName + ".back", AppDomain.CurrentDomain.FriendlyName);
            }
        }

        private string GetMD5HashFromFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }


    }
}
