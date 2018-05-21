using System;

namespace conways_game_of_life.lib
{
	public class Ticker
	{

		private ILivingNeighborCalculator LivingNeighborCalculator { get; set; }

		public Ticker(ILivingNeighborCalculator calculator)
		{
			LivingNeighborCalculator = calculator;
		}

		public Cell[,] Tick(Cell[,] board)
		{
			var xMax = board.GetLength(0);
			var yMax = board.GetLength(1);

			var result = new Cell[xMax, yMax];

			for (var i = 0; i < xMax; i++)
			{
				for (var j = 0; j < yMax; j++)
				{
					result[i, j] = IsAliveAfterTick(board, i, j);
				}
			}

			return result;
		}

		private Cell IsAliveAfterTick(Cell[,] board, int x, int y)
		{
			var isAliveNow = board[x, y].Alive;
			var numLivingNeighbors = LivingNeighborCalculator.Calc(board, x, y);

			// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
      if (isAliveNow && numLivingNeighbors < 2) return new Cell() { Alive = false };
      // Any live cell with two or three live neighbours lives on to the next generation.
      if (isAliveNow && numLivingNeighbors == 2) return new Cell() { Alive = true };
      if (isAliveNow && numLivingNeighbors == 3) return new Cell() { Alive = true };
      // Any live cell with more than three live neighbours dies, as if by overcrowding.
      if (isAliveNow && numLivingNeighbors > 3) return new Cell() { Alive = false };
      // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
      if (!isAliveNow && numLivingNeighbors == 3) return new Cell() { Alive = true };

      return new Cell() { Alive = false };
		}
	}

	public class LivingNeighborCalculator_Toroidal : ILivingNeighborCalculator
	{
		public int Calc(Cell[,] board, int x, int y)
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