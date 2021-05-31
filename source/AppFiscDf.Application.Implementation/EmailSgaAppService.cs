using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Implementation
{
    public class EmailSgaAppService : IEmailSgaAppService
    {
        private readonly IEmailSgaService _emailSgaService;

        public EmailSgaAppService(IEmailSgaService emailSgaService)
        {
            _emailSgaService = emailSgaService;
        }

        public async Task<MessageResponse<string>> SendEmail(string emaildestinatario, string nomedestinatario, string assunto, string conteudo)
        {
            var messageResponse = new MessageResponse<string>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.SendEmail),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(nomedestinatario) || string.IsNullOrEmpty(emaildestinatario) || string.IsNullOrEmpty(assunto) || string.IsNullOrEmpty(conteudo))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    EmailResponse email = new EmailResponse();
                    email.Recipients.Add(new ContactResponse() { Email = emaildestinatario, Name = nomedestinatario });
                    email.Message = new MensagemResponse() { Subject = assunto, Content = conteudo, Typemessage = Typemessage.TEXTO };

                    var result = await _emailSgaService.SendEmail(email);
                    messageResponse.Data = result;
                    messageResponse.Message = (messageResponse.Data != null) ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccesssendEMail) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.IsSuccess = false;
                    messageResponse.Message = e.Message.ToString();
                }
            }

            return messageResponse;
        }

        public async Task<MessageResponse<string>> SendEmail(EmailResponse emailResponse)
        {
            var messageResponse = new MessageResponse<string>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.SendEmail),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if ((emailResponse.Recipients.Count == 0) || (string.IsNullOrEmpty(emailResponse.Message.Subject)) || (string.IsNullOrEmpty(emailResponse.Message.Content)))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var result = await _emailSgaService.SendEmail(emailResponse);
                    messageResponse.Data = result;
                    messageResponse.Message = (messageResponse.Data != null) ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccesssendEMail) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.IsSuccess = false;
                    messageResponse.Message = e.Message.ToString();
                }
            }

            return messageResponse;
        }

        public async Task<string> VerifyEmailErro(decimal inspectionDocumentId)
        {
            return await _emailSgaService.VerifyEmailErro(inspectionDocumentId);
        }
    }
}