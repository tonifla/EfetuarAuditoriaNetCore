using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocServiceOrderMapper
    {
        public static InsDocServiceOrder ConvertToObject(this InsDocServiceOrderRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocServiceOrder
            {
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                Number = requestResponse.Number,
                Year = requestResponse.Year,
                NrUfId = requestResponse.NrUfId,
                Type = requestResponse.Type
            };
        }

        public static InsDocServiceOrderRequestResponse ConvertToRequestResponse(this InsDocServiceOrder insDocServiceOrder)
        {
            if (insDocServiceOrder == null) return null;

            return new InsDocServiceOrderRequestResponse
            {
                InspectionDocumentId = insDocServiceOrder.InspectionDocumentId,
                Number = insDocServiceOrder.Number,
                Year = insDocServiceOrder.Year,
                NrUfId = insDocServiceOrder.NrUfId,
                Type = insDocServiceOrder.Type
            };
        }

        public static InsDocServiceOrder ConvertObjectUpdated(InsDocServiceOrderRequestResponse request, InsDocServiceOrder original)
        {
            if (request == null) return null;

            original.InspectionDocumentId = request.InspectionDocumentId;
            original.Number = request.Number;
            original.Year = request.Year;
            original.NrUfId = request.NrUfId;
            original.Type = request.Type;

            return original;
        }
    }
}