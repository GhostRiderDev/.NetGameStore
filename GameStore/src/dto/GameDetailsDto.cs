namespace app.dto;

public record class GameDetailsDto(
  int Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);

