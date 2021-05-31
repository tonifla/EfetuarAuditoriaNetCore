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
    public class NrUfController : ApiController
    {
        private readonly INrUfAppService _nrUfAppService;

        public NrUfController(INrUfAppService nrUfAppService)
        {
            _nrUfAppService = nrUfAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<NrUfResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _nrUfAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }
    }
}