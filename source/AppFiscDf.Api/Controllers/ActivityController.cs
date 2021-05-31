using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class ActivityController : ApiController
    {
        private readonly IActivityAppService _activityAppService;

        public ActivityController(IActivityAppService activityAppService)
        {
            _activityAppService = activityAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<ActivityResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _activityAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]/{name}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<ActivityResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromRoute] string name)
        {
            var result = await _activityAppService.ListByActivityAsync(name);
            return await Response(result.StatusCode, result);
        }
    }
}