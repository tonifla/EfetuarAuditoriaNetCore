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
    public class UorgAppService : IUorgAppService
    {
        private readonly IUorgService _uorgService;

        public UorgAppService(IUorgService uorgService)
        {
            _uorgService = uorgService;
        }

        public async Task<MessageResponse<UorgResponse>> FindByUorgAsync(string acronym)
        {
            var messageResponse = new MessageResponse<UorgResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfUorg),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(acronym))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var uorg = await _uorgService.FindByUorgAsync(acronym);
                    messageResponse.Data = uorg;
                    messageResponse.Message = (messageResponse.Data != null) ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyFinded) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
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
    }
}