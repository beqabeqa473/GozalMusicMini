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
        public partial class ReportIssue : Form
    {
        private MainForm mform;
        public ReportIssue(MainForm ParentForm)
        {
            InitializeComponent();
            mform = ParentForm;
        }

        private async void btnReport_ClickAsync(object sender, EventArgs e)
        {
            string body = "Reported by " + mform.FullName + Environment.NewLine + commentTxt.Text;
            var values = new Dictionary<string, string>
{
{"method", "reportissue"},
{"title", titleTxt.Text},
{"body", body}
};
            string response = await mform.MakeVKGetRequest(values);
            MessageBox.Show("Issue created", "Thank you");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void commentTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }
    }
}
