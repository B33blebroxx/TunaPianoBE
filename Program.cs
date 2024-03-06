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
app.MapPost("/songs", (TunaPianoBEDbContext db, Song song) =>
{
    db.Songs.Add(song);
    db.SaveChanges();
    return Results.Created($"/song/new/{song.Id}", song);
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

//Search/filter songs by genreId
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


app.Run();

