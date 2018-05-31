using GozaltechVKAuthClient;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace GozalMusicMini
{
    public partial class AuthForm : Form
    {
        private SecureConnection secure;
        public AuthForm()
        {
            InitializeComponent();
            secure = new SecureConnection();
            secure.OnConnectionEstablished += new SecureConnection.ConnectionEstablishedHandler(secure_OnConnectionEstablished);
            secure.OnResponseReceived += new SecureConnection.ResponseReceivedHandler(secure_OnResponseReceived);
            secure.SetServerURL("https://gozaltech.org/auth/");
            secure.EstablishSecureConnectionAsync();
            button1.Enabled = false;
        }

        private void secure_OnResponseReceived(object sender, ResponseReceivedEventArgs e)
        {
            button1.Enabled = true;
            JObject credentials = JObject.Parse(e.Response);
            string token = credentials["token"].ToString();
            int uid = (int)credentials["uid"];
            if (token.Length != 0 && uid != 0)
            {
                var MyIni = new IniFile();
                MyIni.Write("Token", token);
                MyIni.Write("UserID", uid.ToString());
                MessageBox.Show("Authorization succeeded", "Success");
                secure.CloseConnection();
                new MainForm().ShowDialog();
                this.Close();
            } else {
                MessageBox.Show("Authorization failed, check your credentials!", "Error");
            }
            }

        private void secure_OnConnectionEstablished(object sender, OnConnectionEstablishedEventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secure.CloseConnection();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length >= 5) {
            string data = $"authorize,{textBox1.Text},{textBox2.Text}";
            if (secure.ReadyToSendData)
            {
                secure.SendDataSecureAsync(data);
                    button1.Enabled = false;
                }
        } else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("some of fields are not filled", "Error");
            }
        }
    }
}
