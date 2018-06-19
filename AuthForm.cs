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
            JObject credentials = JObject.Parse(e.Response);
            string token = credentials["token"].ToString();
            int uid = (int)credentials["uid"];
            if (token.Length != 0 && uid != 0)
            {
                var MyIni = new IniFile();
                MyIni.Write("Token", token);
                MyIni.Write("UserID", uid.ToString());
                MessageBox.Show("Авторизация прошла успешно", "Успешно");
                secure.CloseConnection();
                new MainForm().ShowDialog();
                this.Close();
            } else {
                MessageBox.Show("Авторизация не удалась", "Ошибка");
            }
            }

        private void secure_OnConnectionEstablished(object sender, OnConnectionEstablishedEventArgs e)
        {
            btnLogin.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            secure.CloseConnection();
            this.Close();
        }

    }
}
