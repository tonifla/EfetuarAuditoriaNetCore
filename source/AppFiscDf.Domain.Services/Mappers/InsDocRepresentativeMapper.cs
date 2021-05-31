using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocRepresentativeMapper
    {
        public static InsDocRepresentative ConvertToObject(this InsDocRepresentativeRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocRepresentative
            {
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                Name = requestResponse.Name,
                Document = requestResponse.Document,
                Employment = requestResponse.Employment,
                SignatureDate = requestResponse.SignatureDate,
                SignatureImage = requestResponse.SignatureImage
            };
        }

        public static InsDocRepresentativeRequestResponse ConvertToRequestResponse(this InsDocRepresentative insDocRepresentative)
        {
            if (insDocRepresentative == null) return null;

            return new InsDocRepresentativeRequestResponse
            {
                InspectionDocumentId = insDocRepresentative.InspectionDocumentId,
                Name = insDocRepresentative.Name,
                Document = insDocRepresentative.Document,
                Employment = insDocRepresentative.Employment,
                SignatureDate = insDocRepresentative.SignatureDate,
                SignatureImage = insDocRepresentative.SignatureImage
            };
        }

        public static InsDocRepresentative ConvertObjectUpdated(InsDocRepresentativeRequestResponse request, InsDocRepresentative original)
        {
            if (request == null) return null;

            original.InspectionDocumentId = request.InspectionDocumentId;
            original.Name = request.Name;
            original.Document = request.Document;
            original.Employment = request.Employment;
            original.SignatureDate = request.SignatureDate;
            original.SignatureImage = request.SignatureImage;

            return original;
        }
    }
}