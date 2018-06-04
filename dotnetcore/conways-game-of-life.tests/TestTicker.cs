using conways_game_of_life.core;
using conways_game_of_life.lib;
using Xunit;

namespace conways_game_of_life.tests
{
  public class TestTicker : ITicker
  {
    public ICell[,] Tick(ICell[,] board)
    {
      return board;
    }
  }
}
