using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class UorgController : ApiController
    {
        private readonly IUorgAppService _uorgAppService;

        public UorgController(IUorgAppService uorpAppService)
        {
            _uorgAppService = uorpAppService;
        }

        [HttpGet]
        [Route("[action]/{acronymUorg}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<UorgResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromRoute] string acronymUorg)
        {
            var result = await _uorgAppService.FindByUorgAsync(acronymUorg);
            return await Response(result.StatusCode, result);
        }
    }
}