using AppFiscDf.Application.Model.RequestResponse;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IEmailSgaAppService
    {
        Task<MessageResponse<string>> SendEmail(string emaildestinatario, string nomedestinatario, string assunto, string conteudo);

        Task<MessageResponse<string>> SendEmail(EmailResponse emailResponse);

        Task<string> VerifyEmailErro(decimal inspectionDocumentId);
    }
}