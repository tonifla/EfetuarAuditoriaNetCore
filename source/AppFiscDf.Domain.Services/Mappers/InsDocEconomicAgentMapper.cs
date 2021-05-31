using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocEconomicAgentMapper
    {
        public static InsDocEconomicAgent ConvertToObject(this InsDocEconomicAgentRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocEconomicAgent
            {
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                UfReference = requestResponse.UfReference,
                ActivityId = requestResponse.ActivityId,
                AuthorizationNumber = requestResponse.AuthorizationNumber,
                CpfCnpj = requestResponse.CpfCnpj,
                InspectedUnit = requestResponse.InspectedUnit,
                CompanyName = requestResponse.CompanyName,
                Name = requestResponse.Name,
                Address = requestResponse.Address,
                Neighborhood = requestResponse.Neighborhood,
                ZipCode = requestResponse.ZipCode,
                City = requestResponse.City,
                AddressComplement = requestResponse.AddressComplement,
                Block = requestResponse.Block,
                CellPhone = requestResponse.CellPhone,
                Phone = requestResponse.Phone,
                Email = requestResponse.Email,
                PublicationDf = requestResponse.PublicationDf
            };
        }

        public static InsDocEconomicAgentRequestResponse ConvertToRequestResponse(this InsDocEconomicAgent insDocEconomicAgent)
        {
            if (insDocEconomicAgent == null) return null;

            return new InsDocEconomicAgentRequestResponse
            {
                InspectionDocumentId = insDocEconomicAgent.InspectionDocumentId,
                UfReference = insDocEconomicAgent.UfReference,
                ActivityId = insDocEconomicAgent.ActivityId,
                AuthorizationNumber = insDocEconomicAgent.AuthorizationNumber,
                CpfCnpj = insDocEconomicAgent.CpfCnpj,
                InspectedUnit = insDocEconomicAgent.InspectedUnit,
                CompanyName = insDocEconomicAgent.CompanyName,
                Name = insDocEconomicAgent.Name,
                Address = insDocEconomicAgent.Address,
                Neighborhood = insDocEconomicAgent.Neighborhood,
                ZipCode = insDocEconomicAgent.ZipCode,
                City = insDocEconomicAgent.City,
                AddressComplement = insDocEconomicAgent.AddressComplement,
                Block = insDocEconomicAgent.Block,
                CellPhone = insDocEconomicAgent.CellPhone,
                Phone = insDocEconomicAgent.Phone,
                Email = insDocEconomicAgent.Email,
                PublicationDf = insDocEconomicAgent.PublicationDf
            };
        }

        public static InsDocEconomicAgent ConvertObjectUpdated(InsDocEconomicAgentRequestResponse request, InsDocEconomicAgent original)
        {
            if (request == null) return null;

            original.InspectionDocumentId = request.InspectionDocumentId;
            original.UfReference = request.UfReference;
            original.ActivityId = request.ActivityId;
            original.AuthorizationNumber = request.AuthorizationNumber;
            original.CpfCnpj = request.CpfCnpj;
            original.InspectedUnit = request.InspectedUnit;
            original.CompanyName = request.CompanyName;
            original.Name = request.Name;
            original.Address = request.Address;
            original.Neighborhood = request.Neighborhood;
            original.ZipCode = request.ZipCode;
            original.City = request.City;
            original.AddressComplement = request.AddressComplement;
            original.Block = request.Block;
            original.CellPhone = request.CellPhone;
            original.Phone = request.Phone;
            original.Email = request.Email;
            original.PublicationDf = request.PublicationDf;

            return original;
        }
    }
}