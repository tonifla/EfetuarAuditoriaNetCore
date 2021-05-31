using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InspectionAgentMapper
    {
        public static InspectionAgentResponse ConvertToResponse(this InspectionAgent inspectionAgent) => ConvertObjectToResponse(inspectionAgent);

        public static InspectionAgentResponse ConvertObjectToResponse(InspectionAgent inspectionAgent)
        {
            if (inspectionAgent == null) return null;

            return new InspectionAgentResponse
            {
                InspectionAgentId = inspectionAgent.InspectionAgentId,
                Name = inspectionAgent.Name,
                Employment = inspectionAgent.Employment,
                Organ = inspectionAgent.OrganOfOrigin,
                NrUfId = inspectionAgent.NrUfId,
                Registry = inspectionAgent.Registry,
                SignatureImage = inspectionAgent.SignatureImage,
                SignatureDate = inspectionAgent.SignatureDate,
                Login = inspectionAgent.Login,
                Email = inspectionAgent.Email,
                Cpf = inspectionAgent.Cpf,
                Status = inspectionAgent.Status
            };
        }

        internal static InspectionAgent ConvertToObject(this InspectionAgentResponse response)
        {
            return new InspectionAgent
            {
                InspectionAgentId = response.InspectionAgentId,
                Name = response.Name,
                Employment = response.Employment,
                OrganOfOrigin = response.Organ,
                NrUfId = response.NrUfId,
                Registry = response.Registry,
                SignatureImage = response.SignatureImage,
                SignatureDate = response.SignatureDate,
                Login = response.Login,
                Email = response.Email,
                Cpf = response.Cpf,
                Status = response.Status
            };
        }

        public static InspectionAgentResponse ConvertToResponsePanel(this InspectionAgent inspectionAgent) => ConvertObjectPanelToResponse(inspectionAgent);

        public static InspectionAgentResponse ConvertObjectPanelToResponse(InspectionAgent inspectionAgent)
        {
            if (inspectionAgent == null) return null;

            return new InspectionAgentResponse
            {
                InspectionAgentId = inspectionAgent.InspectionAgentId,
                Name = inspectionAgent.Name,
                Employment = inspectionAgent.Employment,
                Organ = inspectionAgent.OrganOfOrigin,
                NrUfId = inspectionAgent.NrUfId,
                Registry = inspectionAgent.Registry,
                SignatureImage = inspectionAgent.SignatureImage,
                SignatureDate = inspectionAgent.SignatureDate,
                Login = inspectionAgent.Login,
                Email = inspectionAgent.Email,
                Cpf = inspectionAgent.Cpf,
                Status = inspectionAgent.Status,
                SequentialRequestResponses = inspectionAgent.SequentialList?.Select(p => p.ConvertToRequestResponse()).ToList()
            };
        }
    }
}