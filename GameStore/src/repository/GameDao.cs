using System;
using app.dto;

namespace app.repository;

public class GameDao
{
  public static List<GameDto> GetGameDtos() {
    List<GameDto> gameDtos = [
      new GameDto(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, new DateOnly(2017, 3, 3)),
      new GameDto(2, "Super Mario Odyssey", "Platformer", 59.99m, new DateOnly(2017, 10, 27)),
      new GameDto(3, "Hollow Knight", "Metroidvania", 14.99m, new DateOnly(2017, 2, 24)),
      new GameDto(4, "Celeste", "Platformer", 19.99m, new DateOnly(2018, 1, 25)),
      new GameDto(5, "Dead Cells", "Roguelike", 24.99m, new DateOnly(2018, 8, 7)),
      new GameDto(6, "Stardew Valley", "Simulation", 14.99m, new DateOnly(2016, 2, 26)),
      new GameDto(7, "Hades", "Roguelike", 24.99m, new DateOnly(2020, 9, 17)),
      new GameDto(8, "Ori and the Will of the Wisps", "Platformer", 29.99m, new DateOnly(2020, 3, 11)),
      new GameDto(9, "Cuphead", "Run and gun", 19.99m, new DateOnly(2017, 9, 29)),
      new GameDto(10, "Ori and the Blind Forest", "Platformer", 19.99m, new DateOnly(2015, 3, 11))
    ];
    return gameDtos;
  }
}
