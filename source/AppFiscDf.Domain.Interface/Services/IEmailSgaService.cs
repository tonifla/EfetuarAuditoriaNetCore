using AppFiscDf.Application.Model.RequestResponse;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IEmailSgaService
    {
        Task<string> SendEmail(EmailResponse emailResponse);

        Task<string> VerifyEmailErro(decimal InspectionDocumentId);
    }
}