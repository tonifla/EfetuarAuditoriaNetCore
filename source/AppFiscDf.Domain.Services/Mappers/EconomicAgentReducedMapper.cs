using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class EconomicAgentReducedMapper
    {
        public static EconomicAgentReducedResponse ConvertToResponse(this EconomicAgentReduced economicAgentReduced) => ConvertObjectToResponse(economicAgentReduced);

        public static EconomicAgentReducedResponse ConvertObjectToResponse(EconomicAgentReduced economicAgentReduced)
        {
            if (economicAgentReduced == null) return null;

            return new EconomicAgentReducedResponse
            {
                EconomicAgentReducedId = economicAgentReduced.EconomicAgentReducedId,
                InstallationCnpj = economicAgentReduced.InstallationCnpj,
                Company = economicAgentReduced.Company,
                District = economicAgentReduced.District,
                UfAcronym = economicAgentReduced.UfAcronym
            };
        }

        internal static EconomicAgentReduced ConvertToObject(this EconomicAgentReducedResponse response)
        {
            return new EconomicAgentReduced
            {
                EconomicAgentReducedId = response.EconomicAgentReducedId,
                InstallationCnpj = response.InstallationCnpj,
                Company = response.Company,
                District = response.District,
                UfAcronym = response.UfAcronym
            };
        }
    }
}