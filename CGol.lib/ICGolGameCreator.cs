using System;

namespace CGol.lib
{
	public enum BoardGenerator
	{
		Random,
		Blank,
		Symmetric
	}

	public interface ICGolGameCreator
	{
		int Width { get; set; }
		int Height { get; set; }
		double FillFactor { get; set; }
		BoardGenerator Generator { get; set; }
		ICGolGame Execute();
	}

	public class CGolGameCreator : ICGolGameCreator
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public double FillFactor { get; set; }
		public BoardGenerator Generator { get; set; }

		public ICGolGame Execute()
		{
			switch (Generator)
			{
				case BoardGenerator.Random:
					return RandomBoard();
				case BoardGenerator.Blank:
					return BlankBoard();
				case BoardGenerator.Symmetric:
					return SymmetricBoard();
			}

			throw new Exception("No idea");
		}

		private ICGolGame SymmetricBoard()
		{
			const int minWidth = 20;
			const int minHeight = 20;

			if (Width < minWidth) Width = minWidth;
			if (Height < minHeight) Height = minHeight;

			var board = InitializeGame();

			var centerX = (int) Math.Floor((decimal) (Width / 2)) - 1;
			var centerY = (int) Math.Floor((decimal) (Width / 2)) - 1;
			
			board.Board[centerX, centerY].Alive = true;
			board.Board[centerX + 1, centerY].Alive = true;
			board.Board[centerX, centerY + 1].Alive = true;
			board.Board[centerX + 1, centerY + 1].Alive = true;

			board = DrawVerticalLine(board, centerX - 3, centerY - 3, centerY + 4);
			board = DrawVerticalLine(board, centerX + 4, centerY - 3, centerY + 4);

			board = DrawHorozontalLine(board, centerY - 3, centerX - 3, centerX + 4);
			board = DrawHorozontalLine(board, centerY + 4, centerX - 3, centerX + 4);

			return board;
		}

		private ICGolGame DrawHorozontalLine(ICGolGame board, int y, int xFrom, int xTo)
		{
			for (var x = xFrom; x <= xTo; x++)
			{
				board.Board[x, y].Alive = true;
			}

			return board;
		}

		private ICGolGame DrawVerticalLine(ICGolGame board, int x, int yFrom, int yTo)
		{
			for (var y = yFrom; y <= yTo; y++)
			{
				board.Board[x, y].Alive = true;
			}

			return board;
		}

		private ICGolGame BlankBoard()
		{
			return InitializeGame();
		}

		private ICGolGame RandomBoard()
		{
			var game = InitializeGame();

			var rand = new Random();

			for (var i = 0; i < Width; i++)
			{
				for (var j = 0; j < Height; j++)
				{
					var shouldBeAlive = rand.NextDouble() < FillFactor;

					game.Board[i, j] = new Cell { Alive = shouldBeAlive };
				}
			}

			return game;
		}

		private ICGolGame InitializeGame()
		{
			var game = new CGolGame
			{
				Board = new Cell[Width, Height]
			};

			for (var i = 0; i < Width; i++)
			{
				for (var j = 0; j < Height; j++)
				{
					game.Board[i, j] = new Cell { Alive = false };
				}
			}

			return game;
		}
	}
}