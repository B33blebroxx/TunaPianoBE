using Microsoft.EntityFrameworkCore;
using TunaPianoBE.Models;

namespace TunaPianoBE
{
    public class TunaPianoBEDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }

        public TunaPianoBEDbContext(DbContextOptions<TunaPianoBEDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist
                {
                    Id = 1,
                    Name = "Obie Jessett",
                    Age = 32,
                    Bio = "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.",
                    Song_Count = 40
                },
                new Artist
                {
                    Id = 2,
                    Name = "Aurora Northall",
                    Age = 21,
                    Bio = "Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.",
                    Song_Count = 11
                },
                new Artist
                {
                    Id = 3,
                    Name = "Big Name J",
                    Age = 26,
                    Bio = "Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.\n\nIn congue. Etiam justo. Etiam pretium iaculis justo.",
                    Song_Count = 26
                },
                new Artist
                {
                    Id = 4,
                    Name = "Stella",
                    Age = 35,
                    Bio = "Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.",
                    Song_Count = 101
                },
                new Artist
                {
                    Id = 5,
                    Name = "Carri Key",
                    Age = 27,
                    Bio = "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem."
                }
            });

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre
                {
                    Id = 1,
                    Description = "Pop"
                },
                new Genre
                {
                    Id = 2,
                    Description = "Hip Hop"
                },
                new Genre
                {
                    Id = 3,
                    Description = "Rock"
                },
                new Genre
                {
                    Id = 4,
                    Description = "Jazz"
                },
                new Genre
                {
                    Id = 5,
                    Description = "R&B"
                }
            });

            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song
                {
                    Id = 1,
                    Title = "Not Enough Jazz",
                    ArtistId = 4,
                    Album = "More Jazz",
                    Length = 360,
                    GenreId = 4
                },
                new Song
                {
                    Id = 2,
                    Title = "Lounge Shimmer",
                    ArtistId = 4,
                    Album = "More Jazz",
                    Length = 333,
                    GenreId = 4
                },
                new Song
                {
                    Id = 3,
                    Title = "Big Name",
                    ArtistId = 3,
                    Album = "Self-Titled",
                    Length = 237,
                    GenreId = 2
                },
                new Song
                {
                    Id = 4,
                    Title = "Daybreak",
                    ArtistId = 2,
                    Album = "Not Quite Yet",
                    Length = 226,
                    GenreId = 5
                },
                new Song
                {
                    Id = 5,
                    Title = "All In Time",
                    ArtistId = 1,
                    Album = "The Days Ahead",
                    Length = 222,
                    GenreId = 2
                }
            });
        }
    }
}

