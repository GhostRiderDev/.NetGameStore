using app.entity;
using app.repository;
using app.service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GameStoreTest;

public class GameServiceTest
{
    private Mock<IGameRepository> gameRepositoryMock;

    public GameServiceTest()
    {
        gameRepositoryMock = new Mock<IGameRepository>();
    }

    [Fact(DisplayName = "List all games")]
    public async void FindGames()
    {
        IAsyncEnumerable<Game> games = new List<Game> {
            new() { Id = 1, Name = "Start war II", Price = 100, ReleaseDate = new DateOnly(2021, 1, 1) },
            new() { Id = 2, Name = "CoD World at War", Price = 200, ReleaseDate = new DateOnly(2021, 1, 1) },
            new() { Id = 3, Name = "GTA V", Price = 300, ReleaseDate = new DateOnly(2021, 1, 1) },
            new Game { Id = 4, Name = "FIFA 2021", Price = 400, ReleaseDate = new DateOnly(2021, 1, 1) }
        }.AsQueryable().AsAsyncEnumerable();

        gameRepositoryMock.Setup(x => x.FindGames()).Returns(games);

        GameService gameService = new GameService(gameRepositoryMock.Object);

        var gamesFound = await gameService.FindGames();
        var testGames = gamesFound.ToList();
        Assert.Equal(4, testGames.Count);
    }
}