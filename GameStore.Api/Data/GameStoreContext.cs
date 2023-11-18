using System.Reflection;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data
{
    public class GameStoreContext : DbContext
    {
        private DbSet<Game> games = null!;

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
            games = Set<Game>();
        }

        public DbSet<Game> Games => games;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
