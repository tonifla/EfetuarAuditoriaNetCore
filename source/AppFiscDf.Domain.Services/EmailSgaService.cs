using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class EmailSgaService : IEmailSgaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailSgaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> SendEmail(EmailResponse emailResponse)
        {
            return await _unitOfWork.EmailSga.SendEmailSmtp(emailResponse);
        }

        public async Task<string> VerifyEmailErro(decimal inspectionDocumentId)
        {
            return await _unitOfWork.EmailSga.VerifyEmailErro(inspectionDocumentId);
        }
    }
}