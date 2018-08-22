using conways_game_of_life.core;

namespace conways_game_of_life.lib
{
  public class LivingNeighborCalculator : ILivingNeighborCalculator
  {
    public int Calc(ICell[,] board, int x, int y)
    {
      var xMin = x - 1;
      var xMax = x + 1;
      var yMin = y - 1;
      var yMax = y + 1;

      if (xMin < board.GetLowerBound(0)) xMin = board.GetLowerBound(0);
      if (xMax > board.GetUpperBound(0)) xMax = board.GetUpperBound(0);
      if (yMin < board.GetLowerBound(1)) yMin = board.GetLowerBound(1);
      if (yMax > board.GetUpperBound(1)) yMax = board.GetUpperBound(1);


      var numNeighbors = 0;

      for (var i = xMin; i <= xMax; i++)
      {
        for (var j = yMin; j <= yMax; j++)
        {
          if (i == x && j == y) continue;

          if (board[i, j].Alive) numNeighbors++;
        }
      }

      return numNeighbors;
    }
  }
}