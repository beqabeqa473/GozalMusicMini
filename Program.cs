using System;
using System.Windows.Forms;

namespace GozalMusicMini
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }
            Starter_Form starterForm = new Starter_Form();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(starterForm);
            if (starterForm.IsLoggedIn)
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new AuthForm());
            }
            SingleInstance.Stop();
        }
    }
}
