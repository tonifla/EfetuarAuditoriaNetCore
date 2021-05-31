using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class SequentialController : ApiController
    {
        private readonly ISequentialAppService _sequentialAppService;

        public SequentialController(ISequentialAppService sequentialAppService)
        {
            _sequentialAppService = sequentialAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<SequentialRequestResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _sequentialAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]/{inspectionAgentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<SequentialRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<IEnumerable<SequentialRequestResponse>>> Find([FromRoute] decimal inspectionAgentId)
        {
            var result = await _sequentialAppService.ListBySequentialAsync(inspectionAgentId);
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/{inspectionAgentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<SequentialRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> FindNext([FromRoute] decimal inspectionAgentId)
        {
            var result = await _sequentialAppService.FindBySequentialAsync(inspectionAgentId);
            return await Response(result.StatusCode, result);
        }

        [HttpPost]
        [Route("[action]/{inspectionAgentId}/{sequentialCodeStart}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<SequentialRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> InsertSequentialPanel([FromRoute] decimal inspectionAgentId, decimal sequentialCodeStart, decimal sequentialCodeEnd)
        {
            var result = await _sequentialAppService.InsertSequentialAsync(inspectionAgentId, sequentialCodeStart, sequentialCodeEnd);
            return await Response(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("[action]/{inspectionAgentId}/{sequentialCodeStart}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<SequentialRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> DeleteSequentialPanel([FromRoute] decimal inspectionAgentId, decimal sequentialCodeStart, decimal sequentialCodeEnd)
        {
            var result = await _sequentialAppService.DeleteSequentialAsync(inspectionAgentId, sequentialCodeStart, sequentialCodeEnd);
            return await Response(result.StatusCode, result);
        }
    }
}