using System;
using api.Data;
using api.Dtos;
using api.Entities;

namespace api.Endpoints;

public static class GamesEndpoints
{
    const string GamesURLname = "GetGameById";

    private  static List<GameDto> games = [
        new GameDto(1, "Super Mario Bros.", "Platformer", 29.99m, new DateOnly(1985, 9, 13)),
        new GameDto(2, "The Legend of Zelda", "Action-adventure", 49.99m, new DateOnly(1986, 2, 21)),
        new GameDto(3, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
        new GameDto(4, "Portal 2", "Puzzle-platformer", 9.99m, new DateOnly(2011, 4, 18)),
        new GameDto(5, "Half-Life 2", "First-person shooter", 9.99m, new DateOnly(2004, 11, 16))
    ];

    
    public static RouteGroupBuilder MapEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");
        //GET
        group.MapGet("/", () => games);
        //GET by id
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find((game) => game.Id == id);

            return game is null ? Results.NotFound() : Results.NoContent();
        }).WithName("GetGameById");

        //POST 
        group.MapPost("/", (CreateGameDto newgame , GameStoreContext dbContext) =>
        {
           
            Game game = new(){
                Name = newgame.Name,
                //Genre = dbContext.Genres.Find(newgame.GenreId),
                GenreId = newgame.GenreId,
                Price = newgame.Price,
                ReleaseDate = newgame.ReleaseDate
        };
        dbContext.Games.Add(game);
        dbContext.SaveChanges();
            return Results.Json(game);
        });

        //PUT
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto(id, updateGame.Name, updateGame.Genre, updateGame.Price, updateGame.ReleaseDate);

            return Results.Json(games);
        });

        //DELETE
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
