using app.dto;
using app.entity;

namespace app.mapper;

public static class GenreMapper
{
  public static Genre toEntity(this SummaryGenreDto genreDto)
  {
    return new Genre
    {
      Name = genreDto.Name
    };
  }


  public static GenreDto toDto(this Genre genre)
  {
    return new GenreDto(genre.Id, genre.Name);
  }
}