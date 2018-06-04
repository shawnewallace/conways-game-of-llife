using conways_game_of_life.core;

namespace conways_game_of_life.lib
{
  public class Game : ICGolGame
  {
    public ITicker Ticker { get; }
    public double FillFactor { get; set; }
    public int Height { get; }
    public int Width { get; }
    public ICell[,] Board { get; set; }

    public Game(ITicker ticker)
    {
      Ticker = ticker;
    }

    public bool IsAliveAt(int x, int y)
    {
      return Board[x, y].Alive;
    }

    public void Tick()
    {
      Board = Ticker.Tick(Board);
    }
  }
}