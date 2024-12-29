using api.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

List<GameDto> games = [
    new GameDto(1, "Super Mario Bros.", "Platformer", 29.99m, new DateOnly(1985, 9, 13)),
    new GameDto(2, "The Legend of Zelda", "Action-adventure", 49.99m, new DateOnly(1986, 2, 21)),
    new GameDto(3, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
    new GameDto(4, "Portal 2", "Puzzle-platformer", 9.99m, new DateOnly(2011, 4, 18)),
    new GameDto(5, "Half-Life 2", "First-person shooter", 9.99m, new DateOnly(2004, 11, 16))
];


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("games", () => games);
app.MapGet("games/{id}", (int id) => games.Find((game) => game.Id == id)).WithName("GetAGame");
app.MapGet("/", () => "Hello World");
app.MapPost("games", (CreateGameDto gameDto) =>
{
    games.Add(new GameDto(games.Count + 1, gameDto.Name, gameDto.Genre, gameDto.Price, gameDto.ReleaseDate));

    return Results.StatusCode(200);
});
app.Run();

