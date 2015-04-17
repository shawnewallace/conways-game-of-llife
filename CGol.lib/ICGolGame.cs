namespace CGol.lib
{
	public interface ICGolGame
	{
		double FillFactor { get; set; }
		int Height { get; }
		int Width { get; }
		Cell[,] Board { get; set; }
		bool IsAliveAt(int x, int y);
		void Tick();
	}

	public class CGolGame : ICGolGame
	{
		public double FillFactor { get; set; }
		public int Height { get { return Board.GetLength(1); } }
		public int Width { get { return Board.GetLength(0); } }
		public Cell[,] Board { get; set; }

		public bool IsAliveAt(int x, int y)
		{
			return Board[x, y].Alive;
		}

		public void Tick()
		{
			var ticker = new CGolBoardTicker();
			Board = ticker.Execute(Board);
		}
	}
}