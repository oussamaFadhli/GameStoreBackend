using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetNameEndpointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {

            var group = routes.MapGroup("games/").WithParameterValidation();
            //Get all games
            group.MapGet("/", (IGamesRepository repository) =>
            repository.GetAll().Select(game => game.AsDto()));
            //get game per id
            group.MapGet("/{id}", (IGamesRepository repository, int id) =>
            {
                Game? game = repository.Get(id);
                return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
            }).WithName(GetNameEndpointName);
            //Post Game Method
            group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
            {
                Game? game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImgUrl = gameDto.ImgUrl
                };
                repository.Create(game);
                return Results.CreatedAtRoute(GetNameEndpointName, new { id = game.Id }, game);
            });
            //Put game method
            group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updateGameDto) =>
            {
                Game? existingGame = repository.Get(id);
                if (existingGame is null) return Results.NotFound();

                existingGame.Name = updateGameDto.Name;
                existingGame.Genre = updateGameDto.Genre;
                existingGame.Price = updateGameDto.Price;
                existingGame.ReleaseDate = updateGameDto.ReleaseDate;
                existingGame.ImgUrl = updateGameDto.ImgUrl;

                repository.Update(existingGame);

                return Results.NoContent();
            });
            //Delete game method
            group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
            {
                Game? game = repository.Get(id);
                if (game is not null) repository.Delete(id);
                return Results.NoContent();
            });
            return group;
        }
    }

}