using app.data;
using app.dto;
using app.entity;
using app.mapper;
using Microsoft.EntityFrameworkCore;

namespace app.service;

public class GameService
{
  public async Task<List<GameDto>> FindGames(GameStoreContext dbContext)
  {
    return await dbContext.Games.Include(game => game.Genre)
                              .Select(game => game.toDto())
                              .AsNoTracking()
                              .ToListAsync();
  }

  public async Task<Game> FindGame(int id, GameStoreContext dbContext)
  {
    Game? gameFound = await dbContext.Games
                                     .Include(game => game.Genre)
                                     .FirstOrDefaultAsync(game => game.Id == id);
    if (gameFound == null)
    {
      throw new Exception("Game not found");
    }
    return gameFound;
  }

  public async Task<Game> CreateGame(CreateGameDto newGame, GameStoreContext context)
  {
    Game gameToSave = newGame.toEntity();
    gameToSave.Genre = await context.Genres.FindAsync(newGame.GenreId);

    context.Games.Add(gameToSave);
    await context.SaveChangesAsync();

    return gameToSave;
  }

  public async Task<Game> UpdateGame(int id, UpdateGameDto updateGameDto, GameStoreContext dbContext)
  {
    var gameFound = await dbContext.Games.FindAsync(id);

    if (gameFound is null)
    {
      return gameFound;
    }

    Game? gameToUpdate = updateGameDto.toEntity(id);

    dbContext.Entry(gameFound).CurrentValues.SetValues(gameToUpdate);
    await dbContext.SaveChangesAsync();
    return gameToUpdate;
  }


  public async Task<Game> DeleteGame(int id, GameStoreContext dbContext)
  {
    var gameFound = await dbContext.Games.FindAsync(id);

    if (gameFound is null)
    {
      return gameFound;
    }

    await dbContext.Games.Where(game => game.Id == id)
                   .ExecuteDeleteAsync();

    return gameFound;
  }
}