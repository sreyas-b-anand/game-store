using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace api.Data
{
    public class GameStoreContextFactory : IDesignTimeDbContextFactory<GameStoreContext>
    {
        public GameStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();

            // Get the connection string from the environment variable
            string? connectionString = Environment.GetEnvironmentVariable("SQLITE_CONNECTION_STRING");

            // If the connection string is null or empty, throw an exception
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found in environment variables.");
            }

            // Use the connection string from the environment variable
            optionsBuilder.UseSqlite(connectionString);

            return new GameStoreContext(optionsBuilder.Options);
        }
    }
}
