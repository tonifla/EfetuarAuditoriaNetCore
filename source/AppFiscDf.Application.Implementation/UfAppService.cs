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
    public class UfAppService : IUfAppService
    {
        private readonly IUfService _ufService;

        public UfAppService(IUfService ufService)
        {
            _ufService = ufService;
        }

        public async Task<MessageResponse<IEnumerable<UfResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<UfResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfUf),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var uf = await _ufService.ListAsync();
                messageResponse.Data = uf;
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

        public async Task<MessageResponse<IEnumerable<UfResponse>>> ListByUfAsync(string ufAcronym, string name)
        {
            var messageResponse = new MessageResponse<IEnumerable<UfResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfUf),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(ufAcronym) && string.IsNullOrEmpty(name))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var uf = await _ufService.ListByUfAsync(ufAcronym, name);
                    messageResponse.Data = uf;
                    messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
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