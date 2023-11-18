/*
using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new()
        {
            // Initial game data
        };

        public Task<IEnumerable<Game>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Game>>(games);
        }

        public Task<Game?> GetAsync(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            return Task.FromResult(game);
        }

        public Task CreateAsync(Game game)
        {
            game.Id = games.Count > 0 ? games.Max(g => g.Id) + 1 : 1;
            games.Add(game);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Game updatedGame)
        {
            var existingGame = games.FirstOrDefault(g => g.Id == updatedGame.Id);
            if (existingGame != null)
            {
                int index = games.IndexOf(existingGame);
                games[index] = updatedGame;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var gameToRemove = games.FirstOrDefault(g => g.Id == id);
            if (gameToRemove != null)
            {
                games.Remove(gameToRemove);
            }
            return Task.CompletedTask;
        }
    }
}
*/
