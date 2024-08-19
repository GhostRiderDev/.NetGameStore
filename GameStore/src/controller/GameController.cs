using app.data;
using app.dto;
using app.entity;
using app.mapper;
using app.service;
using Microsoft.AspNetCore.Mvc;

namespace app.controller;

[ApiController]
[Route("games")]
public class GameController(IGameService gameServiceInject) : ControllerBase
{
    const string getGameNameEndpoint = "GetGame";

    private IGameService gameService = gameServiceInject;

    [HttpGet("")]
    public async Task<List<GameDto>> GetGames()
    {
        return await gameService.FindGames();
    }

    [HttpGet("{id}", Name = getGameNameEndpoint)]
    public async Task<IResult> GetGame([FromRoute] int id, GameStoreContext dbContext)
    {
        Game gameFound = await gameService.FindGame(id, dbContext);
        return gameFound is null ? Results.NotFound($"Game not found with id {id}") : Results.Ok(gameFound.toDto());
    }


    [HttpPost("create")]
    public async Task<IResult> CreateGame([FromBody] CreateGameDto newGame, GameStoreContext dbContext)
    {
        var gameSaved = await gameService.CreateGame(newGame, dbContext);
        return Results.CreatedAtRoute(getGameNameEndpoint, new { id = gameSaved.Id }, gameSaved.toDto());
    }


    [HttpPut("update/{id}")]
    public async Task<IResult> UpdateGame(int id, [FromBody] UpdateGameDto updateGameDto, GameStoreContext dbContext)
    {
        Game? gameUpdated = await gameService.UpdateGame(id, updateGameDto, dbContext);

        if (gameUpdated is null)
        {
            return Results.NotFound($"Game not found with id ${id}");
        }

        return Results.CreatedAtRoute(getGameNameEndpoint, new { id }, gameUpdated.toDto());
    }


    /// <summary>
    /// Deletes a specific Game.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    /// <response code="204">If the game was delete sucessfully</response>
    /// <response code="404">Returns if not exits game</response>
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IResult> DeleteGame(int id, GameStoreContext dbContext)
    {
        var gameFound = await gameService.DeleteGame(id, dbContext);

        if (gameFound is null)
        {
            return Results.NotFound($"Game not found with id ${id}");
        }

        return Results.NoContent();
    }

}
