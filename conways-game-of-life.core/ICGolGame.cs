using conways_game_of_life.core;

namespace conways_game_of_life.core
{
  public interface ICGolGame
  {
    double FillFactor { get; set; }
    int Height { get; }
    int Width { get; }
    ICell[,] Board { get; set; }
    bool IsAliveAt(int x, int y);
    void Tick();
    BoardGenerator Generator { get; set; }
  }
}