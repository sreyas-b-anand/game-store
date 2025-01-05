using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public record class CreateGameDto
(
  string Name,
    string Genre,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
);