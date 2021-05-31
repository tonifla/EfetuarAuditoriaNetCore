using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class EconomicAgentController : ApiController
    {
        private readonly IEconomicAgentAppService _economicAgentAppService;
        private readonly string fileNameJson = "AgenteEconomico.json";
        private readonly string fileNameCsv = "AgenteEconomico.csv";
        private readonly string fileNameZip = "AgenteEconomico.zip";

        public EconomicAgentController(IEconomicAgentAppService economicAgentAppService)
        {
            _economicAgentAppService = economicAgentAppService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<EconomicAgentResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _economicAgentAppService.ListAsync();
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<EconomicAgentResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromQuery] string installationCnpj, string company)
        {
            var result = await _economicAgentAppService.ListByEconomicAgentAsync(installationCnpj, company);
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetFileJsonAsync()
        {
            var result = await _economicAgentAppService.ListAsync();

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
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetFileCsvAsync()
        {
            var result = await _economicAgentAppService.ListFileCsvAsync();

            return File(result,
                        "text/csv",
                        fileNameCsv);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetFileCsvZipAsync()
        {
            var result = await _economicAgentAppService.ListFileCsvAsync();

            using var ms = new MemoryStream();

            using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                var zipEntry = archive.CreateEntry(fileNameCsv, CompressionLevel.Fastest);
                var zipStream = zipEntry.Open();
                zipStream.Write(result, 0, result.Length);
            }

            return File(ms.ToArray(),
                        "application/zip",
                        fileNameZip);
        }
    }
}