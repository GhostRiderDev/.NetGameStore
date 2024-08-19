using app.data;
using app.dto;
using app.entity;

namespace app.service;

public interface IGameService
{
  Task<List<GameDto>> FindGames();
  Task<Game> FindGame(int id, GameStoreContext dbContext);
  Task<Game> CreateGame(CreateGameDto newGame, GameStoreContext context);
  Task<Game> UpdateGame(int id, UpdateGameDto updateGameDto, GameStoreContext dbContext);
  Task<Game> DeleteGame(int id, GameStoreContext dbContext);
}
