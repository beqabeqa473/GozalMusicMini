using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace GozalMusicMini
{
    public partial class Starter_Form : Form
    {
        public bool IsLoggedIn { get; set; }
        public Starter_Form()
        {
            InitializeComponent();
        }

        private async void Starter_Form_LoadAsync(object sender, System.EventArgs e)
        {
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
                    MessageBox.Show("Access denied", "Error");
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
    }
}
