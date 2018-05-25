using GozalMusicMini.Properties;
using GozaltechVKAuthClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            JObject credentials = JObject.Parse(e.Response);
            string token = credentials["token"].ToString();
            int uid = (int)credentials["uid"];
            if (token.Length != 0 && uid != 0)
            {
                Program.settings.access_token = token;
                Program.settings.user_id = uid;
                Program.settings.auth = true;
                Program.settings.Save();
                MessageBox.Show("Authorization succeeded", "Success");
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length >= 5) {
            string data = textBox1.Text + "," + textBox2.Text;
            if (secure.ReadyToSendData)
            {
                secure.SendDataSecureAsync(data);
            }
        } else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("some of fields are not filled", "Error");
            }
        }
    }
}
