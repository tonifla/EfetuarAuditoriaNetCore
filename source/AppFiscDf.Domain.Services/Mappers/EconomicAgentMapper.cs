using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class EconomicAgentMapper
    {
        public static EconomicAgentResponse ConvertToResponse(this EconomicAgent economicAgent) => ConvertObjectToResponse(economicAgent);

        public static EconomicAgentResponse ConvertObjectToResponse(EconomicAgent economicAgent)
        {
            if (economicAgent == null) return null;

            return new EconomicAgentResponse
            {
                EconomicAgentId = economicAgent.EconomicAgentId,
                InstallationCnpj = economicAgent.InstallationCnpj,
                Company = economicAgent.Company,
                ZipCode = economicAgent.ZipCode,
                Title = economicAgent.Title,
                Address = economicAgent.Address,
                Number = economicAgent.Number,
                Complement = economicAgent.Complement,
                Neighborhood = economicAgent.Neighborhood,
                District = economicAgent.District,
                State = economicAgent.State,
                AuthorizationNumber = string.IsNullOrEmpty(economicAgent.AuthorizationNumber) ? null : economicAgent.AuthorizationNumber.ToString().Split(','),
                PublicationDate = string.IsNullOrEmpty(economicAgent.PublicationDate) ? null : economicAgent.PublicationDate.ToString().Split(','),
                Status = economicAgent.Status,
                InstallationType = string.IsNullOrEmpty(economicAgent.InstallationType) ? null : economicAgent.InstallationType.ToString().Split(','),
                InstallationIdentification = economicAgent.InstallationIdentification,
                ReducedCompany = economicAgent.ReducedCompany,
                AdministratorCnpj = economicAgent.AdministratorCnpj,
                EffectiveStartDate = economicAgent.EffectiveStartDate,
                EffectiveEndDate = economicAgent.EffectiveEndDate,
                UfAcronym = economicAgent.UfAcronym
            };
        }

        internal static EconomicAgent ConvertToObject(this EconomicAgentResponse response)
        {
            return new EconomicAgent
            {
                EconomicAgentId = response.EconomicAgentId,
                InstallationCnpj = response.InstallationCnpj,
                Company = response.Company,
                ZipCode = response.ZipCode,
                Title = response.Title,
                Address = response.Address,
                Number = response.Number,
                Complement = response.Complement,
                Neighborhood = response.Neighborhood,
                District = response.District,
                State = response.State,
                AuthorizationNumber = response.AuthorizationNumber != null ? string.Join(",", response.AuthorizationNumber) : null,
                PublicationDate = response.PublicationDate != null ? string.Join(",", response.PublicationDate) : null,
                Status = response.Status,
                InstallationType = response.InstallationType != null ? string.Join(",", response.InstallationType) : null,
                InstallationIdentification = response.InstallationIdentification,
                ReducedCompany = response.ReducedCompany,
                AdministratorCnpj = response.AdministratorCnpj,
                EffectiveStartDate = response.EffectiveStartDate,
                EffectiveEndDate = response.EffectiveEndDate,
                UfAcronym = response.UfAcronym
            };
        }
    }
}