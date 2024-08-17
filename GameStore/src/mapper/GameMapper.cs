using app.dto;
using app.entity;

namespace app.mapper;

public static class GameMapper
{
  public static Game toEntity(this CreateGameDto createGameDto)
  {
    return new Game
    {
      Name = createGameDto.Name,
      GenreId = createGameDto.GenreId,
      Price = createGameDto.Price,
      ReleaseDate = createGameDto.ReleaseDate
    };
  }
  public static GameDto toDto(this Game game)
  {
    return new GameDto(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);
  }

  public static Game toEntity(this UpdateGameDto updateGameDto, int id)
  {
    return new Game
    {
      Id = id,
      Name = updateGameDto.Name,
      GenreId = updateGameDto.GenreId,
      Price = updateGameDto.Price,
      ReleaseDate = updateGameDto.ReleaseDate
    };
  }
}