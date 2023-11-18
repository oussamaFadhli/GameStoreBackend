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
            group.MapGet("/", async (IGamesRepository repository) =>
            (await repository.GetAllAsync()).Select(game => game.AsDto()));
            //get game per id
            group.MapGet("/{id}",async (IGamesRepository repository, int id) =>
            {
                Game? game = await repository.GetAsync(id);
                return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
            }).WithName(GetNameEndpointName);
            //Post Game Method
            group.MapPost("/",async (IGamesRepository repository, CreateGameDto gameDto) =>
            {
                Game? game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImgUrl = gameDto.ImgUrl
                };
                await repository.CreateAsync(game);
                return Results.CreatedAtRoute(GetNameEndpointName, new { id = game.Id }, game);
            });
            //Put game method
            group.MapPut("/{id}", async(IGamesRepository repository, int id, UpdateGameDto updateGameDto) =>
            {
                Game? existingGame = await repository.GetAsync(id);
                if (existingGame is null) return Results.NotFound();

                existingGame.Name = updateGameDto.Name;
                existingGame.Genre = updateGameDto.Genre;
                existingGame.Price = updateGameDto.Price;
                existingGame.ReleaseDate = updateGameDto.ReleaseDate;
                existingGame.ImgUrl = updateGameDto.ImgUrl;

                await repository.UpdateAsync(existingGame);

                return Results.NoContent();
            });
            //Delete game method
            group.MapDelete("/{id}",async (IGamesRepository repository, int id) =>
            {
                Game? game = await repository.GetAsync(id);
                if (game is not null) await repository.DeleteAsync(id);
                return Results.NoContent();
            });
            return group;
        }
    }

}