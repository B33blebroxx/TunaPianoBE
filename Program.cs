using TunaPianoBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using TunaPianoBE;



var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<TunaPianoBEDbContext>(builder.Configuration["TunaPianoBEDbConnectionString"]);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//SONGS

//Post new song
app.MapPost("/songs", (TunaPianoBEDbContext db, Song newSong) =>
{
    db.Songs.Add(newSong);
    db.SaveChanges();
    return Results.Created($"/songs/{newSong.Id}", newSong);
});

//Get all songs
app.MapGet("/songs", (TunaPianoBEDbContext db) =>
{
    var songs = db.Songs.ToList();

    if (songs == null)
    {
        return Results.NotFound("No songs found.");
    }
    return Results.Ok(songs);
});

//Get single song
app.MapGet("/songs/{id}", (TunaPianoBEDbContext db, int id) =>
{
    return db.Songs.Where(s => s.Id == id).Include(s => s.Genre).Include(s => s.Artist);
});

//Delete song
app.MapDelete("/songs/{id}", (TunaPianoBEDbContext db, int id) =>
{
    var songToDelete = db.Songs.SingleOrDefault(s => s.Id == id);

    if (songToDelete == null)
    {
        return Results.NotFound("No song with that Id.");
    }
    db.Songs.Remove(songToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

//Edit song
app.MapPut("/songs/{id}", (TunaPianoBEDbContext db, int id, Song song) =>
{
    var songToUpdate = db.Songs.SingleOrDefault(s => s.Id == id);
    if (songToUpdate == null)
    {
        return Results.NotFound("No song with that id.");
    }
    songToUpdate.Title = song.Title;
    songToUpdate.ArtistId = song.ArtistId;
    songToUpdate.Album = song.Album;
    songToUpdate.Length = song.Length;
    songToUpdate.GenreId = song.GenreId;

    db.SaveChanges();
    return Results.Ok("Song updated");
});

//Search/filter songs by genreId (stretch)
app.MapGet("/songs/genre/{genreId}", (TunaPianoBEDbContext db, int genreId) =>
{
    var songsOfGenreType = db.Songs.Where(s => s.GenreId == genreId)
    .ToList();

    if (songsOfGenreType == null)
    {
        return Results.NotFound("No songs matching that genre.");
    }
    return Results.Ok(songsOfGenreType);
});


//ARTISTS

//Create an Artists
app.MapPost("/artists", (TunaPianoBEDbContext db, Artist newArtist) =>
{
    db.Artists.Add(newArtist);
    db.SaveChanges();
    return Results.Created($"/artists/{newArtist.Id}", newArtist);
});

//Get all artists
app.MapGet("/artists", (TunaPianoBEDbContext db) =>
{
    var allArtists = db.Artists.Include(a => a.Song).ToList();

    if (allArtists == null)
    {
        return Results.NotFound("Error, no artists found!");
    }
    return Results.Ok(allArtists);
});

//Delete an artist
app.MapDelete("/artists", (TunaPianoBEDbContext db, int artistId) =>
{
    var artistToDelete = db.Artists.SingleOrDefault(a => a.Id == artistId);

    if (artistToDelete == null)
    {
        return Results.NotFound("No artist with that Id");
    }
    db.Artists.Remove(artistToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

//Update an artist
app.MapPut("/artists/{id}", (TunaPianoBEDbContext db, int id, Artist artist) =>
{
    var artistToUpdate = db.Artists.SingleOrDefault(a => a.Id == id);
    if (artistToUpdate == null)
    {
        return Results.NotFound("No song with that id.");
    }
    artistToUpdate.Name = artist.Name;
    artistToUpdate.Age = artist.Age;
    artistToUpdate.Bio = artist.Bio;

    db.SaveChanges();
    return Results.Ok("Artist updated");
});



app.Run();

