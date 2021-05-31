using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocWitnessMapper
    {
        public static InsDocWitness ConvertToObject(this InsDocWitnessRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocWitness
            {
                InsDocWitnessId = requestResponse.InsDocWitnessId,
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                Name = requestResponse.Name,
                Document = requestResponse.Document,
                Employment = requestResponse.Employment,
                SignatureDate = requestResponse.SignatureDate,
                SignatureImage = requestResponse.SignatureImage
            };
        }

        public static InsDocWitnessRequestResponse ConvertToRequestResponse(this InsDocWitness insDocWitness)
        {
            if (insDocWitness == null) return null;

            return new InsDocWitnessRequestResponse
            {
                InsDocWitnessId = insDocWitness.InsDocWitnessId,
                InspectionDocumentId = insDocWitness.InspectionDocumentId,
                Name = insDocWitness.Name,
                Document = insDocWitness.Document,
                Employment = insDocWitness.Employment,
                SignatureDate = insDocWitness.SignatureDate,
                SignatureImage = insDocWitness.SignatureImage
            };
        }

        public static void ConvertObjectUpdated(InsDocWitnessRequestResponse request, InsDocWitness original)
        {
            original.InsDocWitnessId = request.InsDocWitnessId;
            original.InspectionDocumentId = request.InspectionDocumentId;
            original.Name = request.Name;
            original.Document = request.Document;
            original.Employment = request.Employment;
            original.SignatureDate = request.SignatureDate;
            original.SignatureImage = request.SignatureImage;
        }

        public static List<InsDocWitness> ConvertObjectUpdatedList(List<InsDocWitnessRequestResponse> request, InspectionDocument original)
        {
            original.InsDocWitnessList.Clear();

            if (request != null) original.InsDocWitnessList = request?.Select(p => p.ConvertToObject()).ToList();

            return original.InsDocWitnessList.ToList();
        }
    }
}