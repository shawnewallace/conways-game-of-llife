using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class GameCreator : IGameCreator
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public double FillFactor { get; set; }

		public IGame Execute()
		{
			var board = new Cell[Width, Height];
			var newGame = new Game(board);

			return newGame;
		}
	}
}