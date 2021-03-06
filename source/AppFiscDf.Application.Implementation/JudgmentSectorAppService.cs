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
    public class JudgmentSectorAppService : IJudgmentSectorAppService
    {
        private readonly IJudgmentSectorService _judgmentSectorService;

        public JudgmentSectorAppService(IJudgmentSectorService judgmentSectorService)
        {
            _judgmentSectorService = judgmentSectorService;
        }

        public async Task<MessageResponse<IEnumerable<JudgmentSectorRequestResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<JudgmentSectorRequestResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfJudgmentSector),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var judgmentSector = await _judgmentSectorService.ListAsync();
                messageResponse.Data = judgmentSector;
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