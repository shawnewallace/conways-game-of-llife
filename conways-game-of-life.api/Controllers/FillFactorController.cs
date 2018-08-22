using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace conways_game_of_life.api.Controllers
{
  [Route ("api/[controller]")]
  public class FillFactorController : ControllerBase {
    [HttpGet]
    public ActionResult<IEnumerable<double>> Get () {
      var result = new List<double> ();
      result.Add (.1);
      result.Add (.2);
      result.Add (.3);
      result.Add (.4);
      result.Add (.5);
      result.Add (.6);
      result.Add (.7);
      result.Add (.8);
      result.Add (.9);

      return result;
    }
  }
}