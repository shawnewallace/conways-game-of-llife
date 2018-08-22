using NUnit.Framework;

namespace CGol.lib.tests
{
	[TestFixture]
	public class x
	{
		private Cell[,] _board;
		private CGolBoardTicker _ticker;

		[SetUp]
		public void SetUp()
		{
			_ticker = new CGolBoardTicker();
			_board = CreateBoard(3, 3);
		}
		// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
		[TestCase(0, true, false)]
		[TestCase(1, true, false)]
		// Any live cell with two or three live neighbours lives on to the next generation.
		[TestCase(2, true, true)]
		[TestCase(3, true, true)]		
		// Any live cell with more than three live neighbours dies, as if by overcrowding.
		[TestCase(4, true, false)]
		[TestCase(5, true, false)]
		[TestCase(6, true, false)]
		[TestCase(7, true, false)]
		[TestCase(8, true, false)]
		// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
		[TestCase(0, false, false)]
		[TestCase(1, false, false)]
		[TestCase(2, false, false)]
		[TestCase(3, false, true)]
		[TestCase(4, false, false)]
		[TestCase(5, false, false)]
		[TestCase(6, false, false)]
		[TestCase(7, false, false)]
		[TestCase(8, false, false)]
		public void is_alive_or_dead(int numNeighborsBeforeTick, bool livingBeforeTick, bool livingAfterTick)
		{
			_board[1, 1].Alive = livingBeforeTick;
			SetNeighbors(numNeighborsBeforeTick);

			var newBoard = _ticker.Execute(_board);
			Assert.AreEqual(livingAfterTick, newBoard[1, 1].Alive);
		}

		private void SetNeighbors(int numNeighborsBeforeTick)
		{
			if (numNeighborsBeforeTick == 0) return;
			if (numNeighborsBeforeTick >= 1) _board[0, 0].Alive = true;
			if (numNeighborsBeforeTick >= 2) _board[1, 0].Alive = true;
			if (numNeighborsBeforeTick >= 3) _board[2, 0].Alive = true;
			if (numNeighborsBeforeTick >= 4) _board[0, 1].Alive = true;
			if (numNeighborsBeforeTick >= 5) _board[2, 1].Alive = true;
			if (numNeighborsBeforeTick >= 6) _board[0, 2].Alive = true;
			if (numNeighborsBeforeTick >= 7) _board[1, 2].Alive = true;
			if (numNeighborsBeforeTick == 8) _board[2, 2].Alive = true;
		}

		protected Cell[,] CreateBoard(int width, int height)
		{
			var result = new Cell[width, height];

			for (var i = 0; i < width; i++)
				for (var j = 0; j < height; j++)
					result[i, j] = new Cell() { Alive = false };

			return result;
		}
	}
}