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
    public class InspectionAgentAppService : IInspectionAgentAppService
    {
        private readonly IInspectionAgentService _inspectionAgentService;

        public InspectionAgentAppService(IInspectionAgentService inspectionAgentService)
        {
            _inspectionAgentService = inspectionAgentService;
        }

        public async Task<MessageResponse<IEnumerable<InspectionAgentResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<InspectionAgentResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionAgent),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var inspectionAgent = await _inspectionAgentService.ListAsync();
                messageResponse.Data = inspectionAgent;
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

        public async Task<MessageResponse<IEnumerable<InspectionAgentResponse>>> ListByInspectionAgentAsync(string name, string registry)
        {
            var messageResponse = new MessageResponse<IEnumerable<InspectionAgentResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionAgent),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(registry))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var inspectionAgent = await _inspectionAgentService.ListByInspectionAgentAsync(name, registry);
                    messageResponse.Data = inspectionAgent;
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

        public async Task<MessageResponse<IEnumerable<InspectionAgentResponse>>> ListByInspectionAgentAsync(bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page)
        {
            var messageResponse = new MessageResponse<IEnumerable<InspectionAgentResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionAgent),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            page = page <= 1 ? 1 : page;

            if ((tipoNrUfOrInspectionAgent && nrUfId <= 0) || (!tipoNrUfOrInspectionAgent && inspectionAgentId <= 0))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var inspectionAgent = await _inspectionAgentService.ListByInspectionAgentAsync(tipoNrUfOrInspectionAgent, nrUfId, inspectionAgentId, page);
                    messageResponse.Data = inspectionAgent;
                    messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                    messageResponse.Page = page;
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

        public async Task<MessageResponse<InspectionAgentResponse>> FindByInspectionAgentAsync(string login, string cpf)
        {
            var messageResponse = new MessageResponse<InspectionAgentResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionAgent),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(cpf))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var inspectionAgent = await _inspectionAgentService.FindByInspectionAgentAsync(login, cpf);
                    messageResponse.Data = inspectionAgent;
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

        public async Task<IEnumerable<InspectionAgentResponse>> ListFileJsonAsync()
        {
            return await _inspectionAgentService.ListAsync();
        }
    }
}