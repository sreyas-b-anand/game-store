using api.Data;
using api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlite<GameStoreContext>(connstring);



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World");

app.MapEndpoints();
//app.MigrateDb();
app.Run();

