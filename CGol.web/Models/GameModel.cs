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

      for (var x = 0; x < Width; x++)
      {
        for (var y = 0; y < Height; y++)
        {
          Board[x, y] = model.IsAliveAt(x, y);
        }
      }
    }

    public ICGolGame ApplyTo(ICGolGame domainGame)
    {
      domainGame.FillFactor = FillFactor;
      domainGame.Board = new Cell[Width,Height];

      for (var x = 0; x < Width; x++)
      {
        for (var y = 0; y < Height; y++)
        {
          domainGame.Board[x, y] = new Cell(){Alive = Board[x,y]};
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