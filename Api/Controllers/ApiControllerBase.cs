using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cgol.Api.Controllers
{
  [ApiController]
  public abstract class ApiControllerBase : ControllerBase
  {
    protected readonly ILogger _logger;

    public ApiControllerBase(ILogger logger) => _logger = logger;

  }
}