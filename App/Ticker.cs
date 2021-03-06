using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class Ticker : ITicker
	{
		private INeighborCalculator neighborCalculator { get; set; }
	
		public Ticker(INeighborCalculator calculator)
		{
			neighborCalculator = calculator;
		}

		public ICell[,] Execute(ICell[,] board)
		{
			var xMax = board.GetLength(0);
			var yMax = board.GetLength(1);

			var result = board;

			for (var i = 0; i < xMax; i++)
				for (var j = 0; j < yMax; j++)
					result[i, j] = IsAliveAfterTick(board, i, j);

			return result;
		}

		private Cell IsAliveAfterTick(ICell[,] board, int x, int y)
		{
			var isAliveNow = board[x, y].Alive;
			var numLivingNeighbors = neighborCalculator.Calc(board, x, y);

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
}