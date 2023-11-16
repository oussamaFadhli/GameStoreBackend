using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetNameEndpointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            InMemGamesRepository repository = new();
            var group = routes.MapGroup("games/").WithParameterValidation();
            //Get all games
            group.MapGet("/", () => repository.GetAll());
            //get game per id
            group.MapGet("/{id}", (int id) =>
            {
                Game? game = repository.Get(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            }).WithName(GetNameEndpointName);
            //Post Game Method
            group.MapPost("/", (Game game) =>
            {
                repository.Create(game);
                return Results.CreatedAtRoute(GetNameEndpointName, new { id = game.Id }, game);
            });
            //Put game method
            group.MapPut("/{id}", (int id, Game updateGame) =>
            {
                Game? existingGame = repository.Get(id);
                if (existingGame is null) return Results.NotFound();
                existingGame.Name = updateGame.Name;
                existingGame.Genre = updateGame.Genre;
                existingGame.Price = updateGame.Price;
                existingGame.ReleaseDate = updateGame.ReleaseDate;
                existingGame.ImgUrl = updateGame.ImgUrl;
                repository.Update(existingGame);
                return Results.NoContent();
            });
            //Delete game method
            group.MapDelete("/{id}", (int id) =>
            {
                Game? game = repository.Get(id);
                if (game is not null) repository.Delete(id);
                return Results.NoContent();
            });
            return group;
        }
    }

}