using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public record class CreateGameDto
(
  string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);