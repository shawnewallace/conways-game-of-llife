using conways_game_of_life.core;

namespace conways_game_of_life.lib
{
  public class Game : ICGolGame
  {
    public ITicker Ticker { get; }
    public double FillFactor { get; set; }
		public int Height { get { return Board.GetLength(0); } }
		public int Width { get { return Board.GetLength(1); } }
    public ICell[,] Board { get; set; }

    public Game(ITicker ticker)
    {
      Ticker = ticker;
    }

    public bool IsAliveAt(int x, int y)
    {
      return Board[x, y].Alive;
    }

    public void Tick()
    {
      Board = Ticker.Tick(Board);
    }

		public override string ToString(){
			var result = "";

			for (int i = 0; i < Width; i++){
				for (var j = 0; j < Height; j++) {
					if (IsAliveAt(i, j))
						result += "O";
					else
						result += "_";
				}
				result += "\n";
			}

			return result;
		}
  }
}