namespace TunaPianoBE.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public int Song_Count { get; set; }
        public int GenreId { get; set; }
        public ICollection<Song> Song { get; set; }
    }
}
