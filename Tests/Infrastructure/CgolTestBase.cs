using Cgol.App.Models;

namespace Cgol.Tests.Infrastructure {
	public abstract class CgolTestBase
	{

		protected Cell[,] _board;

		protected void CreateBoard(int width, int height)
		{
			_board = new Cell[width, height];

			for (var i = 0; i < width; i++)
				for (var j = 0; j < height; j++)
					_board[i, j] = new Cell() { Alive = false };
		}

		protected void SetNumberOfNeighborsBeforeTick(int numNeighborsBeforeTick)
		{
			if (numNeighborsBeforeTick == 0) return;
			_board[0, 0].Alive |= numNeighborsBeforeTick >= 1;
			_board[1, 0].Alive |= numNeighborsBeforeTick >= 2;
			_board[2, 0].Alive |= numNeighborsBeforeTick >= 3;
			_board[0, 1].Alive |= numNeighborsBeforeTick >= 4;
			_board[2, 1].Alive |= numNeighborsBeforeTick >= 5;
			_board[0, 2].Alive |= numNeighborsBeforeTick >= 6;
			_board[1, 2].Alive |= numNeighborsBeforeTick >= 7;
			_board[2, 2].Alive |= numNeighborsBeforeTick == 8;
		}
	}
}