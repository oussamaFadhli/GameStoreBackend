using GameStore.Api.Entities;
const string GetNameEndpointName = "GetGame";
List<Game> games = new(){
    new Game(){
        Id = 1,
        Name = "Street Fighter II",
        Genre = "Fight",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImgUrl = "https://placehold.co/100"

    },
    new Game(){
        Id = 2,
        Name = "Call Of Duty MW3",
        Genre = "Shooter",
        Price = 60M,
        ReleaseDate = new DateTime(2023,11,7),
        ImgUrl = "https://placehold.co/100"
    },
    new Game(){
        Id=3,
        Name = "Forza Horizon 5",
        Genre = "Racing",
        Price = 49.5M,
        ReleaseDate = new DateTime(2021,12,15),
        ImgUrl = "https://placehold.co/100"
    },
    new Game(){
        Id=4,
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 59.99M,
        ReleaseDate = new DateTime(2022,10,1),
        ImgUrl = "https://placehold.co/100"
    }
};
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var group = app.MapGroup("games/").WithParameterValidation();
//Get all games
group.MapGet("/", () => games);
//get game per id
group.MapGet("/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game is null) return Results.NotFound();
    return Results.Ok(game);
}).WithName(GetNameEndpointName);
//Post Game Method
group.MapPost("/", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);
    return Results.CreatedAtRoute(GetNameEndpointName, new { id = game.Id }, game);
});
//Put game method
group.MapPut("/{id}", (int id, Game updateGame) =>
{
    Game? existingGame = games.Find(game => game.Id == id);
    if (existingGame is null) return Results.NotFound();
    existingGame.Name = updateGame.Name;
    existingGame.Genre = updateGame.Genre;
    existingGame.Price = updateGame.Price;
    existingGame.ReleaseDate = updateGame.ReleaseDate;
    existingGame.ImgUrl = updateGame.ImgUrl;
    return Results.NoContent();
});
//Delete game method
group.MapDelete("/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game is not null) games.Remove(game);
    return Results.NoContent();
});
app.Run();
