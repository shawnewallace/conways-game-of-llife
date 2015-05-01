using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using CGol.lib;
using CGol.web.Models;
using Ninject;

namespace CGol.web.Controllers
{
	public class GameController : ApiController
	{
		public ICGolGameCreator Creator
		{
			get { return _creator ?? (_creator = new CGolGameCreator()); }
			set { _creator = value; }
		}
		private ICGolGameCreator _creator;


		// POST: api/Game
		[HttpPost]
		public OkNegotiatedContentResult<GameModel> Post([FromBody] NewGameModel model)
		{
			Creator.Width = model.Width;
			Creator.Height = model.Height;
			Creator.FillFactor = model.FillFactor;
			Creator.Generator = model.Generator;
			var rawGame = Creator.Execute();

			var game = new GameModel(rawGame) { FillFactor = model.FillFactor };
			return Ok(game);
		}

		// PUT: api/Game/5
		[HttpPut]
		public OkNegotiatedContentResult<GameModel> Put([FromBody] GameModel game)
		{
			ICGolGame domainGame = new CGolGame();
			domainGame = game.ApplyTo(domainGame);

			domainGame.Tick();

			return Ok(new GameModel(domainGame));
		}
	}
}
