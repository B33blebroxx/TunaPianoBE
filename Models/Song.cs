namespace TunaPianoBE.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Album { get; set; }
        public int Length { get; set; }
        public int GenreId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Genre>? Genre { get; set; }
    }
}
