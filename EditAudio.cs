using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace GozalMusicMini
{
    public partial class EditAudio : Form
    {

        public int Ownerid { get; set; }
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string LyricsText { get; set; }
public AudioGenre Genre_id { get; set; }
    public bool Nosearch { get; set; }
        IniFile settings;

        public EditAudio()
        {
            InitializeComponent();
            Initializecombo();
            settings = new IniFile();
        }

        private void Initializecombo()
        {
            comboBox1.DataSource = Enum.GetValues(typeof(AudioGenre));
                }        
        
        private void EditAudio_Load(object sender, EventArgs e)
        {
            Text = "edit " + Artist + " - " + Title;
            textBox1.Text = Artist;
            textBox2.Text = Title;
                textBox3.Text = LyricsText;
                comboBox1.SelectedItem = Genre_id;
                }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
           int result = checkBox1.CheckState == CheckState.Checked ? 1 : 0;
            MainForm mform = new MainForm();
            var values = new Dictionary<string, string>
            {
                {"method", "audioedit"},
                { "access_token", settings.Read("Token")},
                {"owner_id", Ownerid.ToString()},
                {"audio_id", Id.ToString()},
                {"artist", textBox1.Text},
                {"text", textBox3.Text},
                {"title", textBox2.Text},
                {"genre_id", ((int)comboBox1.SelectedItem).ToString()},
                {"no_search", result.ToString() }
                };
            string response = await mform.MakeVKGetRequest(values);
if (response.Contains("response")) {
                            MessageBox.Show("Audio edit successful", "Success");
                Close();
                }            
            }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
