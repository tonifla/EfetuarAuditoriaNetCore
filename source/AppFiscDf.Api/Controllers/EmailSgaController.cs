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
    public class EmailSgaController : ApiController
    {
        private readonly IEmailSgaAppService _emailSgaAppService;

        public EmailSgaController(IEmailSgaAppService emailSgaAppService)
        {
            _emailSgaAppService = emailSgaAppService;
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<string>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> SendEmail(string emailDestinatario, string nomeDestinatario, string assunto, string conteudo)
        {
            var result = await _emailSgaAppService.SendEmail(emailDestinatario, nomeDestinatario, assunto, conteudo);
            return await Response(result.StatusCode, result);
        }

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MessageResponse<EmailResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> SendEmailObject([FromBody] EmailResponse emailResponse)
        {
            var result = await _emailSgaAppService.SendEmail(emailResponse);
            return await Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<string>> VerifyEmailErro(int InspectionDocumentId)
        {
            var result = await _emailSgaAppService.VerifyEmailErro(InspectionDocumentId);
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