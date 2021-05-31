using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers.Base
{
    //[Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected ApiController()
        {
        }

        protected new Task<IActionResult> Response(HttpStatusCode statusCode, object result = null)
        {
            if (result == null)
                return Task.FromResult<IActionResult>(StatusCode((int)HttpStatusCode.NoContent));

            return Task.FromResult<IActionResult>(StatusCode((int)statusCode, result));
        }
    }
}