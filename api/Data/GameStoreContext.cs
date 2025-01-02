using System;
using Microsoft.EntityFrameworkCore;
using api.Entities;

namespace api.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;
    }
}
