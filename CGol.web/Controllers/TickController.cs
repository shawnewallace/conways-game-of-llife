using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGol.lib;

namespace CGol.web.Controllers
{
	public class TickController : ApiController
	{
		// GET: api/Tick/5
		public GameModel Put([FromBody] GameModel game)
		{
			ICGolGame domainGame = new CGolGame();
			domainGame = game.ApplyTo(domainGame);

			domainGame.Tick();

			return new GameModel(domainGame);
		}
	}
}
