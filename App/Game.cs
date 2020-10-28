using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class Game : IGame
	{
		public Game() { }
		public Game(Cell[,] board) => Board = board;

		public int Height { get { return Board.GetLength(1); } }
		public int Width { get { return Board.GetLength(0); } }
		public ICell[,] Board { get; }

		public bool IsAliveAt(int x, int y) => Board[x, y].Alive;
		public void Tick() => throw new System.NotImplementedException();
	}
}