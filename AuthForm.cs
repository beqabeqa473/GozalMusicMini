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
            btnLogin.Enabled = false;
        }

        private void secure_OnResponseReceived(object sender, ResponseReceivedEventArgs e)
        {
            btnLogin.Enabled = true;
            JToken credentials = JToken.Parse(e.Response);
            bool success = (bool)credentials["success"];
            if (success == false)
            {
                int errorCode = (int)credentials["code"];
                if (errorCode == 1)
                {
                    MessageBox.Show(credentials["description"].ToString(), "Ошибка");
                }
                else if (errorCode == 2)
                {
                    string value = "";
                    if (InputBox.Show("Подтверждение авторизации", credentials["description"].ToString(), ref value) == DialogResult.OK)
                    {
                        string data = $"authorize,{txtLogin.Text},{txtPassword.Text},{value}";
                        if (secure.ReadyToSendData)
                        {
                            secure.SendDataSecureAsync(data);
                            btnLogin.Enabled = false;
                        }
                    }
                }
                }
                else
            {
                string token = credentials["token"].ToString();
                int uid = (int)credentials["uid"];
                    var MyIni = new IniFile();
                    MyIni.Write("Token", token);
                    MyIni.Write("UserID", uid.ToString());
                MessageBox.Show("Авторизация прошла успешно", "Успешно");
                this.Hide();
                var mform = new MainForm();
                mform.Closed += (s, args) => this.Close();
                mform.Show();
            }
            }

        private void secure_OnConnectionEstablished(object sender, OnConnectionEstablishedEventArgs e)
        {
            btnLogin.Enabled = true;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 0 && txtPassword.Text.Length >= 5) {
            string data = $"authorize,{txtLogin.Text},{txtPassword.Text}";
            if (secure.ReadyToSendData)
            {
                secure.SendDataSecureAsync(data);
                    btnLogin.Enabled = false;
                }
        } else if (txtLogin.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            secure.CloseConnection();
        }

    }
}
