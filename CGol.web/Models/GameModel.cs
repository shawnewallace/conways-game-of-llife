using CGol.lib;
using Newtonsoft.Json;

namespace CGol.web.Models
{
	public class GameModel
	{
		public double FillFactor { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public bool[,] Board { get; set; }

		public GameModel()
		{
		}

		public GameModel(ICGolGame model)
		{
			Height = model.Height;
			Width = model.Width;
			FillFactor = model.FillFactor;

			Board = new bool[Width, Height];

			for (var i = 0; i < Width; i++)
			{
				for (var j = 0; j < Height; j++)
				{
					Board[i, j] = model.IsAliveAt(i, j);
				}
			}
		}

		public ICGolGame ApplyTo(ICGolGame domainGame)
		{
			domainGame.FillFactor = FillFactor;
			domainGame.Board = new Cell[Width,Height];

			for (var i = 0; i < Width; i++)
			{
				for (var j = 0; j < Height; j++)
				{
					domainGame.Board[i, j] = new Cell(){Alive = Board[i,j]};
				}
			}

			return domainGame;
		}

		public string JsonBoard()
		{
			//var json = new JavaScriptSerializer().Serialize(Board);
			var json = JsonConvert.SerializeObject(this);

			return json;
		}
	}
}