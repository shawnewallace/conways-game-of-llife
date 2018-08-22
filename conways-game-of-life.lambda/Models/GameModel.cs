using conways_game_of_life.core;
using conways_game_of_life.lib;
using Newtonsoft.Json;

namespace conways_game_of_life.lamda.Models
{
  public class GameModel
  {
    [JsonProperty(PropertyName = "fillFactor")] public double FillFactor { get; set; }
    [JsonProperty(PropertyName = "height")] public int Height { get; set; }
    [JsonProperty(PropertyName = "width")] public int Width { get; set; }
    [JsonProperty(PropertyName = "board")] public bool[,] Board { get; set; }

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
  }
}