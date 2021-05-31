using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocInspectionAgentMapper
    {
        public static InsDocInspectionAgent ConvertToObject(this InsDocInspectionAgentRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocInspectionAgent
            {
                InspectionAgentId = requestResponse.InspectionAgentId,
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                Sort = requestResponse.Sort
            };
        }

        public static InsDocInspectionAgentRequestResponse ConvertToRequestResponse(this InsDocInspectionAgent insDocInspectionAgent)
        {
            if (insDocInspectionAgent == null) return null;

            return new InsDocInspectionAgentRequestResponse
            {
                InspectionAgentId = insDocInspectionAgent.InspectionAgentId,
                InspectionDocumentId = insDocInspectionAgent.InspectionDocumentId,
                Sort = insDocInspectionAgent.Sort
            };
        }

        public static List<InsDocInspectionAgent> ConvertObjectUpdatedList(List<InsDocInspectionAgentRequestResponse> request, InspectionDocument original)
        {
            original.InsDocInspectionAgentList.Clear();

            if (request != null) original.InsDocInspectionAgentList = request?.Select(p => p.ConvertToObject()).ToList();

            return original.InsDocInspectionAgentList.ToList();
        }
    }
}