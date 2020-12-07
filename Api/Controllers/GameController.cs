using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Cgol.Domain.Infrastructure;

namespace Cgol.Api.Controllers
{

  public class GameController : ApiControllerBase
  {
    private readonly IGameFactory _factory;

    public GameController(IGameFactory factory, ILogger<GameController> logger) : base(logger)
    {
      _factory = factory;
    }

    [HttpPost("/api/game/create")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateGame([FromBody] CreateGameModel model)
    {
      _factory.Width = model.Width;
      _factory.Height = model.Height;
      _factory.FillFactor = model.FillFactor;

      var newGame = _factory.Execute();

      return Created("", newGame);
    }
  }
}