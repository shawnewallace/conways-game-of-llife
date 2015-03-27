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

			var game = new GameModel(rawGame) {FillFactor = model.FillFactor};
			return View(game);
		}

		[System.Web.Mvc.HttpGet]
		public ActionResult Tick()
		{
			var rawGame = (ICGolGame) Session["GAME"];
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
	}
}