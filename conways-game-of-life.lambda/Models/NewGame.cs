using conways_game_of_life.core;

namespace conways_game_of_life.lamda.Models
{
  public class NewGame
  {
    public int height { get; set; }
    public int width { get; set; }
    public double fillFactor { get; set; }
    public BoardGenerator generator { get; set;}
  }
}