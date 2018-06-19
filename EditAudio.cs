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
            cbGenre.DataSource = Enum.GetValues(typeof(AudioGenre));
                }        
        
        private void EditAudio_Load(object sender, EventArgs e)
        {
            Text = Text + $" - {Artist} - {Title}";
            txtArtist.Text = Artist;
            txtTitle.Text = Title;
                txtLyrics.Text = LyricsText;
                cbGenre.SelectedItem = Genre_id;
                }

        private async void btnEdit_ClickAsync(object sender, EventArgs e)
        {
            int result = chkNoSearch.CheckState == CheckState.Checked ? 1 : 0;
            MainForm mform = new MainForm();
            var values = new Dictionary<string, string>
            {
                {"method", "audioedit"},
                { "access_token", settings.Read("Token")},
                {"owner_id", Ownerid.ToString()},
                {"audio_id", Id.ToString()},
                {"artist", txtArtist.Text},
                {"title", txtTitle.Text},
                {"text", txtLyrics.Text},
                {"genre_id", ((int)cbGenre.SelectedItem).ToString()},
                {"no_search", result.ToString() }
                };
            string response = await mform.MakeVKGetRequest(values);
if (response.Contains("response")) {
                            MessageBox.Show("Аудио успешно отредактировано", "Успешно");
                Close();
                }            
            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
