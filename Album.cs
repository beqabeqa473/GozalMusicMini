using System;

namespace GozalMusicMini
{
[Serializable]
    public class Album
    {
        public int id { get; set; }
        public int Owner_id { get; set; }
        public string Title { get; set; }
    }
}
