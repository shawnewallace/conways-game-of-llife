using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conways_game_of_life.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace conways_game_of_life.api.Controllers {
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

  [Route ("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get () {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet ("{id}")]
    public ActionResult<string> Get (int id) {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post ([FromBody] string value) { }

    // PUT api/values/5
    [HttpPut ("{id}")]
    public void Put (int id, [FromBody] string value) { }

    // DELETE api/values/5
    [HttpDelete ("{id}")]
    public void Delete (int id) { }
  }
}