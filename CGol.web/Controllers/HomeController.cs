using System;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CGol.lib;
using Newtonsoft.Json;
using Ninject;

namespace CGol.web.Controllers
{
	public class HomeController : Controller
	{
		[Inject]
		public ICGolGameCreator Creator { get; set; }

		// GET: Home
		public ActionResult Index()
		{
			var random = new Random();
			var randomFillFactor = random.NextDouble();

			var model = new NewGameModel
			{
				Width = 10,
				Height = 10,
				FillFactor = randomFillFactor
			};

			return View(model);
		}

	  [HttpPost]
	  public ActionResult Shawn()
	  {
	    var height = 25;
	    var width = 25;

	    var board = new bool[width, height];

	    for (var i = 0; i < width; i++)
	    {
	      for (var j = 0; j < height; j++)
	      {
	        board[i, j] = false;
	      }
	    }

	    board[0, 0] = true;
	    board[24, 24] = true;

	    var model = new GameModel
	    {
        Height = height,
        Width = width,
        FillFactor = 0,
        Board = board
	    };

	    return View("New", model);
	  }

	  [HttpPost]
		public ActionResult New(NewGameModel model)
		{
			Creator.Width = model.Width;
			Creator.Height = model.Height;
			Creator.FillFactor = model.FillFactor;
			var rawGame = Creator.Execute();
			Session["GAME"] = rawGame;

			var game = new GameModel(rawGame) {FillFactor = model.FillFactor};
			return View("New", game);
		}

		[HttpGet]
		public ActionResult Tick()
		{
			var rawGame = (ICGolGame) Session["GAME"];
			rawGame.Tick();
			Session["GAME"] = rawGame;

			var game = new GameModel(rawGame);

			return View("New", game);
		}
	}

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

	public class NewGameModel
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public double FillFactor { get; set; }
	}
}