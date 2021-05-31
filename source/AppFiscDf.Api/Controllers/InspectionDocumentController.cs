using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class InspectionDocumentController : ApiController
    {
        private readonly IInspectionDocumentAppService _inspectionDocumentAppService;

        public InspectionDocumentController(IInspectionDocumentAppService inspectionDocumentAppService)
        {
            _inspectionDocumentAppService = inspectionDocumentAppService;
        }

        [HttpGet]
        [Route("[action]/{inspectionAgentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<InspectionDocumentReducedResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<IEnumerable<InspectionDocumentReducedResponse>>> FindReduced([FromRoute] decimal inspectionAgentId)
        {
            var result = await _inspectionDocumentAppService.ListByInspectionDocumentAsync(inspectionAgentId, false);
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
        [Route("[action]/{typeInspectionDocument}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> FindPanel([FromRoute] int typeInspectionDocument, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string economicAgentCpfCnpj, string economicAgentCompanyName, decimal nrUfId, string ufAcronym, decimal orderServiceYear, decimal orderServiceNumber, int page)
        {
            var result = await _inspectionDocumentAppService.ListByInspectionDocumentAsync(typeInspectionDocument, inspectionAgentId, startDate, endDate, sequentialCode, economicAgentCpfCnpj, economicAgentCompanyName, nrUfId, ufAcronym, orderServiceYear, orderServiceNumber, page);
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]/{InspectionDocumentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InspectionDocumentRequestResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<InspectionDocumentRequestResponse>> FindByInspectionDocument([FromRoute] decimal InspectionDocumentId)
        {
            var result = await _inspectionDocumentAppService.FindByInspectionDocumentAsync(InspectionDocumentId);
            if (result != null)
            {
                return result;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/{finished}/{inspectionAgentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromRoute] bool finished, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string cpfCnpj, string companyName)
        {
            var result = await _inspectionDocumentAppService.ListByInspectionDocumentAsync(finished, inspectionAgentId, startDate, endDate, sequentialCode, cpfCnpj, companyName);
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]/{inspectionAgentId}/{sequentialCode}/{finished}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<InspectionDocumentRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromRoute] decimal inspectionAgentId, decimal sequentialCode, bool finished)
        {
            var result = await _inspectionDocumentAppService.FindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished);
            return await Response(result.StatusCode, result);
        }

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InspectionDocumentRequestResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<InspectionDocumentRequestResponse>> InsertInspectionDocument([FromBody] InspectionDocumentRequestResponse request)
        {
            var result = await _inspectionDocumentAppService.InsertInspectionDocumentAsync(request);
            if (result != null)
            {
                return result;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InspectionDocumentRequestResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<InspectionDocumentRequestResponse>> UpdateInspectionDocument([FromBody] InspectionDocumentRequestResponse request)
        {
            var result = await _inspectionDocumentAppService.UpdateInspectionDocumentAsync(request);
            if (result != null)
            {
                //ToDo - refatorar para trazer o result atualizado do update
                //return result;
                return await _inspectionDocumentAppService.FindByInspectionDocumentAsync(request.InspectionDocumentId);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/{inspectionAgentId}/{inspectionDocumentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(InspectionDocumentRequestResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<InspectionDocumentRequestResponse>> DeleteInspectionDocument([FromRoute] decimal inspectionAgentId, decimal inspectionDocumentId)
        {
            var result = await _inspectionDocumentAppService.DeleteInspectionDocumentAsync(inspectionAgentId, inspectionDocumentId);
            if (result != null)
            {
                return result;
            }
            else
            {
                return BadRequest();
            }
        }
    }
}