using System.Collections.Generic;
using System.Threading.Tasks;
using conways_game_of_life.api.Models;
using conways_game_of_life.lib;
using Microsoft.AspNetCore.Mvc;

namespace conways_game_of_life.api.Controllers
{

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