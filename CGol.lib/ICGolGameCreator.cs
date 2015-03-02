using System;

namespace CGol.lib
{
	public interface ICGolGameCreator
	{
		int Width { get; set; }
		int Height { get; set; }
		double FillFactor { get; set; }
		ICGolGame Execute();
	}

	public class CGolGameCreator : ICGolGameCreator
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public double FillFactor { get; set; }

		public ICGolGame Execute()
		{
			var game = new CGolGame
			{
				Board = new Cell[Width, Height]
			};

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
	}
}