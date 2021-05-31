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
    public class UfController : ApiController
    {
        private readonly IUfAppService _ufAppService;

        public UfController(IUfAppService ufAppService)
        {
            _ufAppService = ufAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<UfResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _ufAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<UfResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromQuery] string ufAcronym, string name)
        {
            var result = await _ufAppService.ListByUfAsync(ufAcronym, name);
            return await Response(result.StatusCode, result);
        }
    }
}