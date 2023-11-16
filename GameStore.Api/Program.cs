using GameStore.Api.Entities;

List <Game> games = new(){
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

app.MapGet("/", () => "Hello World!");

app.Run();
