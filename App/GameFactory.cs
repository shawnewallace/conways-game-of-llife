using System;
using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class GameFactory : IGameFactory
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public double FillFactor { get; set; }
		private ITicker Ticker { get; }

		public GameFactory(ITicker ticker)
		{
			Ticker = ticker;
		}

		public IGame Execute()
		{
			return InitializeRandomGame();
		}

		private IGame InitializeRandomGame()
		{
			var rand = new Random();
			var newBoard = new Cell[Width, Height];

			for (var i = 0; i < Width; i++)
			{
				for (var j = 0; j < Height; j++)
				{
					newBoard[i, j] = new Cell { Alive = (rand.NextDouble() < FillFactor) };
				}
			}

			return new Game(Ticker, newBoard);
		}
	}
}