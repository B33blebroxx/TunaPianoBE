﻿namespace TunaPianoBE.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Song> Song { get; set; }

        public ICollection<Artist> Artist { get; set; }
    }
}

