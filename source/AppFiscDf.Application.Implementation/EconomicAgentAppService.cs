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
    public class EconomicAgentAppService : IEconomicAgentAppService
    {
        private readonly IEconomicAgentService _economicAgentService;

        public EconomicAgentAppService(IEconomicAgentService economicAgentService)
        {
            _economicAgentService = economicAgentService;
        }

        public async Task<MessageResponse<IEnumerable<EconomicAgentResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<EconomicAgentResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfEconomicAgentExternal),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var economicAgent = await _economicAgentService.ListAsync();
                messageResponse.Data = economicAgent;
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

        public async Task<MessageResponse<IEnumerable<EconomicAgentResponse>>> ListByEconomicAgentAsync(string installationCnpj, string company)
        {
            var messageResponse = new MessageResponse<IEnumerable<EconomicAgentResponse>>()
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
                    var economicAgent = await _economicAgentService.ListByEconomicAgentAsync(installationCnpj, company);
                    messageResponse.Data = economicAgent;
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

        public async Task<byte[]> ListFileCsvAsync()
        {
            var economicAgent = await _economicAgentService.ListAsync();

            var builder = new StringBuilder();
            int count = 0;
            builder.AppendLine("order|economicAgentId|installationCnpj|company|zipCode|title|address|number|complement|neighborhood|district|state|authorizationNumber|publicationDate|status|installationType|installationIdentification|reducedCompany|administratorCnpj|effectiveStartDate|effectiveEndDate|ufAcronym");

            foreach (var item in economicAgent)
            {
                count++;
                builder.AppendLine($"{count}|{item.EconomicAgentId}|{item.InstallationCnpj}|{item.Company}|{item.ZipCode}|{item.Title}|{item.Address}|{item.Number}|{item.Complement}|{item.Neighborhood}|{item.District}|{item.State}|{(item.AuthorizationNumber != null ? string.Join(",", item.AuthorizationNumber) : "")}|{(item.PublicationDate != null ? string.Join(",", item.PublicationDate) : "")}|{item.Status}|{(item.InstallationType != null ? string.Join(",", item.InstallationType) : "")}|{item.InstallationIdentification}|{item.ReducedCompany}|{item.AdministratorCnpj}|{item.EffectiveStartDate}|{item.EffectiveEndDate}|{item.UfAcronym}");
            }

            return Encoding.UTF8.GetBytes(builder.ToString());
        }
    }
}