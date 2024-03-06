﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TunaPianoBE;

#nullable disable

namespace TunaPianoBE.Migrations
{
    [DbContext(typeof(TunaPianoBEDbContext))]
    partial class TunaPianoBEDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("GenreId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("TunaPianoBE.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Song_Count")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 32,
                            Bio = "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.",
                            GenreId = 2,
                            Name = "Obie Jessett",
                            Song_Count = 40
                        },
                        new
                        {
                            Id = 2,
                            Age = 21,
                            Bio = "Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.",
                            GenreId = 5,
                            Name = "Aurora Northall",
                            Song_Count = 11
                        },
                        new
                        {
                            Id = 3,
                            Age = 26,
                            Bio = "Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.\n\nIn congue. Etiam justo. Etiam pretium iaculis justo.",
                            GenreId = 2,
                            Name = "Big Name J",
                            Song_Count = 26
                        },
                        new
                        {
                            Id = 4,
                            Age = 35,
                            Bio = "Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.",
                            GenreId = 4,
                            Name = "Stella",
                            Song_Count = 101
                        },
                        new
                        {
                            Id = 5,
                            Age = 27,
                            Bio = "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.",
                            GenreId = 0,
                            Name = "Carri Key",
                            Song_Count = 0
                        });
                });

            modelBuilder.Entity("TunaPianoBE.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Pop"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Hip Hop"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Rock"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Jazz"
                        },
                        new
                        {
                            Id = 5,
                            Description = "R&B"
                        });
                });

            modelBuilder.Entity("TunaPianoBE.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "More Jazz",
                            ArtistId = 4,
                            GenreId = 4,
                            Length = 360,
                            Title = "Not Enough Jazz"
                        },
                        new
                        {
                            Id = 2,
                            Album = "More Jazz",
                            ArtistId = 4,
                            GenreId = 4,
                            Length = 333,
                            Title = "Lounge Shimmer"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Self-Titled",
                            ArtistId = 3,
                            GenreId = 2,
                            Length = 237,
                            Title = "Big Name"
                        },
                        new
                        {
                            Id = 4,
                            Album = "Not Quite Yet",
                            ArtistId = 2,
                            GenreId = 5,
                            Length = 226,
                            Title = "Daybreak"
                        },
                        new
                        {
                            Id = 5,
                            Album = "The Days Ahead",
                            ArtistId = 1,
                            GenreId = 2,
                            Length = 222,
                            Title = "All In Time"
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("TunaPianoBE.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPianoBE.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TunaPianoBE.Models.Song", b =>
                {
                    b.HasOne("TunaPianoBE.Models.Artist", "Artist")
                        .WithMany("Song")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunaPianoBE.Models.Artist", b =>
                {
                    b.Navigation("Song");
                });
#pragma warning restore 612, 618
        }
    }
}
