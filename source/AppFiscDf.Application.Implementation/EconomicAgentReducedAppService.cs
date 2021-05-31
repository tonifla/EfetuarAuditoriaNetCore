using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Implementation
{
    public class EconomicAgentReducedAppService : IEconomicAgentReducedAppService
    {
        private readonly IEconomicAgentReducedService _economicAgentReducedService;

        public EconomicAgentReducedAppService(IEconomicAgentReducedService economicAgentReducedService)
        {
            _economicAgentReducedService = economicAgentReducedService;
        }

        public async Task<MessageResponse<IEnumerable<EconomicAgentReducedResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<EconomicAgentReducedResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfEconomicAgentExternal),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var economicAgentReduced = await _economicAgentReducedService.ListAsync();
                messageResponse.Data = economicAgentReduced;
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

        public async Task<MessageResponse<IEnumerable<EconomicAgentReducedResponse>>> ListByEconomicAgentReducedAsync(string installationCnpj, string company)
        {
            var messageResponse = new MessageResponse<IEnumerable<EconomicAgentReducedResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfEconomicAgentExternal),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(installationCnpj) && string.IsNullOrEmpty(company))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var economicAgentReduced = await _economicAgentReducedService.ListByEconomicAgentReducedAsync(installationCnpj, company);
                    messageResponse.Data = economicAgentReduced;
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

        public async Task<byte[]> ListFileCsvReducedAsync()
        {
            var economicAgentReduced = await _economicAgentReducedService.ListAsync();

            var builder = new StringBuilder();
            int count = 0;
            builder.AppendLine("order|economicAgentId|installationCnpj_company");

            foreach (var item in economicAgentReduced)
            {
                count++;
                builder.AppendLine($"{count}|{item.EconomicAgentReducedId}|{item.InstallationCnpj} - {item.Company} ({item.District}/{item.UfAcronym})");
            }

            return Encoding.UTF8.GetBytes(builder.ToString());
        }
    }
}