using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocSerializedMapper
    {
        public static InsDocSerialized ConvertToObject(this InsDocSerializedRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocSerialized
            {
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                JsonString = requestResponse.JsonString
            };
        }

        public static InsDocSerializedRequestResponse ConvertToRequestResponse(this InsDocSerialized insDocSerialized)
        {
            if (insDocSerialized == null) return null;

            return new InsDocSerializedRequestResponse
            {
                InspectionDocumentId = insDocSerialized.InspectionDocumentId,
                JsonString = insDocSerialized.JsonString
            };
        }

        public static InsDocSerialized ConvertObjectUpdated(InsDocSerializedRequestResponse request, InsDocSerialized original)
        {
            if (request == null) return null;

            original.InspectionDocumentId = request.InspectionDocumentId;
            original.JsonString = request.JsonString;

            return original;
        }
    }
}