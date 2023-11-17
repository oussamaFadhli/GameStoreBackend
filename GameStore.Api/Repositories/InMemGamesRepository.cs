using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "Street Fighter II",
                Genre = "Fight",
                Price = 19.99M,
                ReleaseDate = new DateTime(1991, 2, 1),
                ImgUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "Call Of Duty MW3",
                Genre = "Shooter",
                Price = 60M,
                ReleaseDate = new DateTime(2023, 11, 7),
                ImgUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "Forza Horizon 5",
                Genre = "Racing",
                Price = 49.5M,
                ReleaseDate = new DateTime(2021, 12, 15),
                ImgUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 4,
                Name = "FIFA 23",
                Genre = "Sports",
                Price = 59.99M,
                ReleaseDate = new DateTime(2022, 10, 1),
                ImgUrl = "https://placehold.co/100"
            }
        };

        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game? Get(int id)
        {
            return games.Find(game => game.Id == id);
        }
        public void Create(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
        }
        public void Update(Game updatedGame)
        {
            var existingGame = games.Find(game => game.Id == updatedGame.Id);
            if (existingGame != null)
            {
                int index = games.IndexOf(existingGame);
                games[index] = updatedGame;
            }
        }

        public void Delete(int id)
        {
            var gameToRemove = games.Find(game => game.Id == id);
            if (gameToRemove != null)
            {
                games.Remove(gameToRemove);
            }
        }

    }
}
