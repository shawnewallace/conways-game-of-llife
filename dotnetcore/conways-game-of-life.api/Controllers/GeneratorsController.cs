using System.Collections.Generic;
using System.Threading.Tasks;
using conways_game_of_life.api.Models;
using conways_game_of_life.core;
using conways_game_of_life.lib;
using Microsoft.AspNetCore.Mvc;

namespace conways_game_of_life.api.Controllers {
  [Route("api/game")]
  public class GamesController : ControllerBase {
    private readonly ICGolGameCreator _creator;

    public GamesController(ICGolGameCreator creator)
    {
      _creator = creator;
    }


    [HttpPost]
    public IActionResult Create([FromBody] NewGame model) {
      if (!ModelState.IsValid) {
        return BadRequest();
      }

      _creator.Height = model.height;
      _creator.Width = model.width;
      _creator.FillFactor = model.fillFactor;
      _creator.Generator = BoardGenerator.Random;

      var game = _creator.Execute();

      return Created("", game);
    }
  }

  [Route ("api/[controller]")]
  public class GeneratorsController : ControllerBase {
    [HttpGet]
    public ActionResult<IEnumerable<Generator>> Get () {
      var result = new List<Generator> ();
      result.Add (new Generator () { id = 0, name = "Random" });
      result.Add (new Generator () { id = 1, name = "Blank" });
      result.Add (new Generator () { id = 2, name = "Symmetric" });
      result.Add (new Generator () { id = 3, name = "Checkerboard" });
      result.Add (new Generator () { id = 4, name = "Gosper's Gliding Gun" });

      return result;
    }
  }
}