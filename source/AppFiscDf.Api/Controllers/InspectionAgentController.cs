using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class InspectionAgentController : ApiController
    {
        private readonly IInspectionAgentAppService _inspectionAgentAppService;
        private readonly string fileNameJson = "AgenteFiscalizacao.json";

        public InspectionAgentController(IInspectionAgentAppService inspectionAgentAppService)
        {
            _inspectionAgentAppService = inspectionAgentAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<InspectionAgentResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _inspectionAgentAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<InspectionAgentResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromQuery] string name, string registry)
        {
            var result = await _inspectionAgentAppService.ListByInspectionAgentAsync(name, registry);
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]/{tipoNrUfOrInspectionAgent}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<InspectionAgentResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> FindPanel([FromRoute] bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page)
        {
            var result = await _inspectionAgentAppService.ListByInspectionAgentAsync(tipoNrUfOrInspectionAgent, nrUfId, inspectionAgentId, page);
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<InspectionAgentResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetFileJson()
        {
            var result = await _inspectionAgentAppService.ListFileJsonAsync();

            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(result, options);

            return File(jsonUtf8Bytes,
                        "application/octet-stream",
                        fileNameJson);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<InspectionAgentResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> FindInspectionAgent([FromQuery] string login, string cpf)
        {
            var result = await _inspectionAgentAppService.FindByInspectionAgentAsync(login, cpf);
            return await Response(result.StatusCode, result);
        }
    }
}