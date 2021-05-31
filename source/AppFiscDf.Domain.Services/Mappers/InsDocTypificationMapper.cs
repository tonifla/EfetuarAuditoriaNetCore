using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocTypificationMapper
    {
        public static InsDocTypification ConvertToObject(this InsDocTypificationRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocTypification
            {
                InsDocTypificationId = requestResponse.InsDocTypificationId,
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                TypificationId = requestResponse.TypificationId,
                JsonOutput = requestResponse.JsonOutput,
                FreeText = requestResponse.FreeText
            };
        }

        public static InsDocTypificationRequestResponse ConvertToRequestResponse(this InsDocTypification insDocTypification)
        {
            if (insDocTypification == null) return null;

            return new InsDocTypificationRequestResponse
            {
                InsDocTypificationId = insDocTypification.InsDocTypificationId,
                InspectionDocumentId = insDocTypification.InspectionDocumentId,
                TypificationId = insDocTypification.TypificationId,
                JsonOutput = insDocTypification.JsonOutput,
                FreeText = insDocTypification.FreeText
            };
        }

        public static List<InsDocTypification> ConvertObjectUpdatedList(List<InsDocTypificationRequestResponse> request, InspectionDocument original)
        {
            original.InsDocTypificationList.Clear();

            if (request != null) original.InsDocTypificationList = request?.Select(p => p.ConvertToObject()).ToList();

            return original.InsDocTypificationList.ToList();
        }
    }
}