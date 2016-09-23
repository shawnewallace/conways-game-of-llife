using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CGol.lib;
using CGol.web.Models;
using Ninject;

namespace CGol.web.Controllers
{
	public class HomeController : Controller
	{
		[Inject]
		public ICGolGameCreator Creator { get; set; }

		[System.Web.Mvc.HttpPost]
		public ActionResult Shawn()
		{
			const int height = 10;
			const int width = 25;

			var board = new bool[width, height];

			for (var i = 0; i < width; i++)
			{
				for (var j = 0; j < height; j++)
				{
					board[i, j] = false;
				}
			}

			// S
			board[1, 1] = true;
			board[2, 1] = true;
			board[3, 1] = true;
			board[4, 1] = true;

			board[1, 4] = true;
			board[2, 4] = true;
			board[3, 4] = true;
			board[4, 4] = true;

			board[1, 7] = true;
			board[2, 7] = true;
			board[3, 7] = true;
			board[4, 7] = true;

			var model = new GameModel
			{
				Height = height, 
				Width = width, 
				FillFactor = 0.0, 
				Board = board
			};

			return View("New", model);
		}

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

		[System.Web.Mvc.HttpPost]
		public ActionResult New(NewGameModel model)
		{
			Creator.Width = model.Width;
			Creator.Height = model.Height;
			Creator.FillFactor = model.FillFactor;
			var rawGame = Creator.Execute();
			Session["GAME"] = rawGame;

			var game = new GameModel(rawGame) { FillFactor = model.FillFactor };
			return View("New", game);
		}

		[System.Web.Mvc.HttpGet]
		public ActionResult Tick()
		{
			var rawGame = (ICGolGame)Session["GAME"];
			rawGame.Tick();
			Session["GAME"] = rawGame;

			var game = new GameModel(rawGame);

			return View("New", game);
		}
	}

	public class NewGameModel
	{
		public int Width { get; set; }
		public int Height { get; set; }
		[Key]
		public double FillFactor { get; set; }
		public BoardGenerator Generator { get; set; }
	}
}