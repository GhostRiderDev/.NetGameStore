
using app.entity;
using Microsoft.EntityFrameworkCore;

namespace app.data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
  public DbSet<Game> Games => Set<Game>();
  public DbSet<Genre> Genres => Set<Genre>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Genre>().HasData(
      new { Id = 1, Name = "Action" },
      new { Id = 2, Name = "Adventure" },
      new { Id = 3, Name = "RPG" },
      new { Id = 4, Name = "Simulation" },
      new { Id = 5, Name = "Strategy" }
    );

    // modelBuilder.Entity<Game>().HasData(
    //   new { Id = 1, Name = "GTA V", GenreId = 1, Price = 29.99m },
    //   new { Id = 2, Name = "The Witcher 3", GenreId = 3, Price = 19.99m },
    //   new { Id = 3, Name = "FIFA 22", GenreId = 1, Price = 59.99m },
    //   new { Id = 4, Name = "The Sims 4", GenreId = 4, Price = 39.99m },
    //   new { Id = 5, Name = "Civilization VI", GenreId = 5, Price = 29.99m }
    // );
  }
}
