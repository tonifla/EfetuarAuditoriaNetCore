using AppFiscDf.Api.Controllers.Base;
using AppFiscDf.Api.Models;
using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Controllers
{
    public class InsDocAttachmentController : ApiController
    {
        private readonly IInsDocAttachmentAppService _insDocAttachmentAppService;

        public InsDocAttachmentController(IInsDocAttachmentAppService insDocAttachmentAppService)
        {
            _insDocAttachmentAppService = insDocAttachmentAppService;
        }

        [HttpGet]
        [Route("[action]/{inspectionDocumentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<IEnumerable<InsDocAttachmentRequestResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> Find([FromRoute] decimal inspectionDocumentId)
        {
            var result = await _insDocAttachmentAppService.ListByInsDocAttachmentAsync(inspectionDocumentId);
            return await Response(result.StatusCode, result);
        }

        private string GetContentType(string fileName)
        {
            string strcontentType = "application/octetstream";
            string ext = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (registryKey != null && registryKey.GetValue("Content Type") != null)
                strcontentType = registryKey.GetValue("Content Type").ToString();
            return strcontentType;
        }

        [HttpGet]
        [Route("[action]/{inspectionDocumentId}/{insDocAttachmentId}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetFileInsDocAttachment(decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            var result = await _insDocAttachmentAppService.GetFileInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);

            if (result.Data == null)
            {
                return await Response(result.StatusCode, result);
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), result.Data.Name);

                return File(result.Data.AttachmentFile,
                            GetContentType(path),
                            Path.GetFileName(path));
            }
        }

        [HttpGet]
        [Route("[action]/{nameAttachmentInsDocFinished}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetFileInsDocAttachment(string nameAttachmentInsDocFinished)
        {
            var result = await _insDocAttachmentAppService.GetFileInsDocAttachmentAsync(nameAttachmentInsDocFinished);

            if (result.Data == null)
            {
                return await Response(result.StatusCode, result);
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), result.Data.Name);

                return File(result.Data.AttachmentFile,
                            GetContentType(path),
                            Path.GetFileName(path));
            }
        }

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<InsDocAttachmentRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> InsertInsDocAttachment([FromBody] InsDocAttachmentRequestResponse insDocAttachmentRequestResponse)
        {
            var result = await _insDocAttachmentAppService.InsertInsDocAttachmentAsync(insDocAttachmentRequestResponse);
            return await Response(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("[action]/{inspectionDocumentId}/{insDocAttachmentId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<InsDocAttachmentRequestResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> DeleteInsDocAttachment([FromRoute] decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            var result = await _insDocAttachmentAppService.DeleteInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);
            return await Response(result.StatusCode, result);
        }
    }
}