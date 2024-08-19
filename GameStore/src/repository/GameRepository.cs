using app.data;
using app.dto;
using app.entity;
using app.mapper;
using Microsoft.EntityFrameworkCore;

namespace app.repository;

public class GameRepository(GameStoreContext gameStoreContext) : IGameRepository
{
  private GameStoreContext dbCtx = gameStoreContext;

  public void DeleteGameById(int gameId)
  {
    throw new NotImplementedException();
  }


  public Game FindGameById(int gameId)
  {
    throw new NotImplementedException();
  }

  public IQueryable<Game> FindGames()
  {
    return dbCtx.Games.Include(game => game.Genre);
  }

  public void InsertGame(Game game)
  {
    throw new NotImplementedException();
  }



  public void UpdateGame(Game game)
  {
    throw new NotImplementedException();
  }
}