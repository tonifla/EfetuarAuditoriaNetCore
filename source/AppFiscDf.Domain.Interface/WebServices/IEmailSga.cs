using AppFiscDf.Application.Model.RequestResponse;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.WebServices
{
    public interface IEmailSga
    {
        Task<string> SendEmailSmtp(EmailResponse emailResponse);

        Task<string> VerifyEmailErro(decimal inspectionDocumentId);
    }
}