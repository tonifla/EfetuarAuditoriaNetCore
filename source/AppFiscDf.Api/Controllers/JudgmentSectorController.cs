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
    public class JudgmentSectorController : ApiController
    {
        private readonly IJudgmentSectorAppService _judgmentSectorAppService;

        public JudgmentSectorController(IJudgmentSectorAppService judgmentSectorAppService)
        {
            _judgmentSectorAppService = judgmentSectorAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<JudgmentSectorRequestResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _judgmentSectorAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }
    }
}