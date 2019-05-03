using System;
using conways_game_of_life.api.Models;
using conways_game_of_life.core;
using conways_game_of_life.lib;
using Microsoft.AspNetCore.Mvc;

namespace conways_game_of_life.api.Controllers
{
  [Route ("api/game")]
  public class GamesController : ControllerBase {
    private readonly ICGolGameCreator _creator;
    private readonly ITicker _ticker;

    public GamesController (ICGolGameCreator creator, ITicker ticker) {
      _creator = creator;
      _ticker = ticker;
    }

    [HttpPost]
    public IActionResult Create ([FromBody] NewGame model) {
      if (!ModelState.IsValid) {
        return BadRequest ();
      }

      _creator.Height = model.height;
      _creator.Width = model.width;
      _creator.FillFactor = model.fillFactor;
      _creator.Generator = model.generator;

      var game = _creator.Execute();

      return Created ("", new GameModel(game));
    }

    [HttpPost]
    [Route ("tick")]
    public IActionResult Tick ([FromBody] GameModel game) {
      ICGolGame domainGame = new Game(_ticker);
			domainGame = game.ApplyTo(domainGame);

			domainGame.Tick();
      return Ok (new GameModel(domainGame));
    }
  }
}