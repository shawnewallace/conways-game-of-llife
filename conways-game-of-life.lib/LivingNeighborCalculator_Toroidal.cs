using conways_game_of_life.core;

namespace conways_game_of_life.lib
{
  public class LivingNeighborCalculator_Toroidal : ILivingNeighborCalculator
  {
    public int Calc(ICell[,] board, int x, int y)
    {
      var xLength = board.GetLength(0);
      var yLength = board.GetLength(1);
      var numNeighbors = 0;


      for (var i = x - 1; i <= x + 1; i++)
      {
        for (var j = y - 1; j <= y + 1; j++)
        {
          if (i == x && j == y) continue;
          var xNext = GetNext(i, xLength);
          var yNext = GetNext(j, yLength);

          if (board[xNext, yNext].Alive) numNeighbors++;
        }
      }

      return numNeighbors;
    }

    private static int GetNext(int index, int max)
    {
      if (index < 0) return max - 1;

      return index % max;
    }
  }
}