using System.ComponentModel.DataAnnotations;
using app.annotation;

namespace app.dto;

public record class CreateGameDto(
  [Required][StringLength(50)][MinLength(5)] string Name,
  [Required] int GenreId,
  [Required][Range(1, 1000)] decimal Price,
  [Required][DateLessThanOrEqualToToday] DateOnly ReleaseDate
);
