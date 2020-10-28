using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class Game : IGame
	{
		public Game()
		{
		}

		public Game(Cell[,] board)
		{
			Board = board;
		}

		public double FillFactor { get; }

		public int Height { get; }

		public int Width { get; }

		public ICell[,] Board { get; set; }

		public bool IsAliveAt(int x, int y)
		{
			throw new System.NotImplementedException();
		}

		public void Tick()
		{
			throw new System.NotImplementedException();
		}
	}
}