using app.entity;

namespace app.repository;

public interface IGameRepository
{
  IQueryable<Game> FindGames();
  Game FindGameById(int gameId);
  void InsertGame(Game game);
  void DeleteGameById(int gameId);
  void UpdateGame(Game game);
}