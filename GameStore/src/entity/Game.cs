
namespace app.entity;

public class Game
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public int GenreId { get; set; }
  public Genre? Genre { get; set; }
  public decimal Price { get; set; }
  public required DateOnly ReleaseDate { get; set; }
  /// <inheritdoc/>

  public override string ToString()
  {

    return $"Id: {Id}, Name: {Name}, Genre: {Genre.Name}, ReleaseDate: {ReleaseDate}";
  }
}
