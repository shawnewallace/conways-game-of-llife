namespace conways_game_of_life.core
{
  public interface ICGolGameCreator
  {
    int Width { get; set; }
    int Height { get; set; }
    double FillFactor { get; set; }
    BoardGenerator Generator { get; set; }
    ICGolGame Execute();
  }
}