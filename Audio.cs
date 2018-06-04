namespace GozalMusicMini
{
    public class Audio
    {
        public int id { get; set; }
        public int Owner_id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int Date { get; set; }
        public string Url { get; set; }
        public int Lyrics_id { get; set; }
        public int Album_id { get; set; }
        public AudioGenre Genre_id { get; set; }
        public bool Is_hq { get; set; }
        public bool Deleted { get; set; }
    }
}
