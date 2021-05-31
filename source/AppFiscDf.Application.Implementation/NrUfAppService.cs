using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Implementation
{
    public class NrUfAppService : INrUfAppService
    {
        private readonly INrUfService _nrUfService;

        public NrUfAppService(INrUfService nrUfService)
        {
            _nrUfService = nrUfService;
        }

        public async Task<MessageResponse<IEnumerable<NrUfResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<NrUfResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfEconomicAgentExternal),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var nrUf = await _nrUfService.ListAsync();
                messageResponse.Data = nrUf;
                messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                messageResponse.IsSuccess = true;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }
    }
}