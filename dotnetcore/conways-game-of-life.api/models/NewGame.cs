namespace conways_game_of_life.api.Models
{
  public class NewGame
  {
    public int height { get; set; }
    public int width { get; set; }
    public double fillFactor { get; set; }
  }
}