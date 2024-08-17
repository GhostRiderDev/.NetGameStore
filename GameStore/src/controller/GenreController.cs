
using app.data;
using app.dto;
using app.entity;
using app.mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.controller;

[ApiController]
[Route("genres")]
public class GenreController : ControllerBase
{

  [HttpGet]
  public async Task<List<Genre>> GetGenres(GameStoreContext dbContext)
  {
    return await dbContext.Genres
      .Select(g => g)
      .AsNoTracking()
      .ToListAsync();
  }


  [HttpGet("{id}")]
  public async Task<IResult> GetGenre(int id, GameStoreContext dbContext)
  {
    Genre? genreFound = await dbContext.Genres.FindAsync(id);
    return genreFound is null ? Results.NotFound($"Genre not found with id {id}") : Results.Ok(genreFound);
  }


  [HttpPost("create")]
  public async Task<IResult> SaveGenre([FromBody] SummaryGenreDto newGenre, GameStoreContext context)
  {
    Genre genreToSave = newGenre.toEntity();
    context.Genres.Add(genreToSave);
    await context.SaveChangesAsync();

    return Results.CreatedAtRoute("GetGenre", new { id = genreToSave.Id }, genreToSave);
  }

  [HttpPut("update/{id}")]
  public async Task<IResult> UpdateGenre(int id, [FromBody] SummaryGenreDto updateGenreDto, GameStoreContext dbContext)
  {
    var genreFound = await dbContext.Genres.FindAsync(id);

    if (genreFound is null)
    {
      return Results.NotFound($"Genre not found with id ${id}");
    }

    var genreToUpdate = updateGenreDto.toEntity();
    genreToUpdate.Id = id;

    dbContext.Genres.Update(genreToUpdate);
    await dbContext.SaveChangesAsync();

    return Results.Ok(genreToUpdate);
  }

  [HttpDelete("delete/{id}")]
  public async Task<IResult> DeleteGenre(int id, GameStoreContext dbContext)
  {
    var genreFound = await dbContext.Genres.FindAsync(id);

    if (genreFound is null)
    {
      return Results.NotFound($"Genre not found with id ${id}");
    }

    dbContext.Genres.Remove(genreFound);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }


}