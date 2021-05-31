using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InspectionDocumentMapper
    {
        public static InspectionDocumentRequestResponse ConvertToResponse(this InspectionDocument inspectionDocument) => ConvertObjectToResponse(inspectionDocument);

        public static InspectionDocumentRequestResponse ConvertObjectToResponse(InspectionDocument inspectionDocument)
        {
            if (inspectionDocument == null) return null;

            return new InspectionDocumentRequestResponse
            {
                InspectionDocumentId = inspectionDocument.InspectionDocumentId,
                UfReference = inspectionDocument.UfReference,
                SequentialCode = inspectionDocument.SequentialCode,
                DocumentNumber = inspectionDocument.DocumentNumber,
                Latitude = inspectionDocument.Latitude,
                Longitude = inspectionDocument.Longitude,
                StartDate = inspectionDocument.StartDate,
                UpdateDate = inspectionDocument.UpdateDate,
                EndDate = inspectionDocument.EndDate,
                JudgmentSectorId = inspectionDocument.JudgmentSectorId,
                InsDocSerializedRequestResponses = InsDocSerializedMapper.ConvertToRequestResponse(inspectionDocument.InsDocSerialized),
                InsDocServiceOrderRequestResponses = InsDocServiceOrderMapper.ConvertToRequestResponse(inspectionDocument.InsDocServiceOrder),
                InsDocEconomicAgentRequestResponses = InsDocEconomicAgentMapper.ConvertToRequestResponse(inspectionDocument.InsDocEconomicAgent),
                InsDocRepresentativeRequestResponses = InsDocRepresentativeMapper.ConvertToRequestResponse(inspectionDocument.InsDocRepresentative),
                InsDocInspectionAgentRequestResponses = inspectionDocument.InsDocInspectionAgentList?.Select(p => p.ConvertToRequestResponse()).ToList(),
                InsDocWitnessRequestResponses = inspectionDocument.InsDocWitnessList?.Select(p => p.ConvertToRequestResponse()).ToList(),
                InsDocTypificationRequestResponses = inspectionDocument.InsDocTypificationList?.Select(p => p.ConvertToRequestResponse()).ToList(),
                InsDocAttachmentRequestResponses = inspectionDocument.InsDocAttachmentList?.Select(p => p.ConvertToResponse()).ToList()
            };
        }

        public static InspectionDocument ConvertRequestToObject(InspectionDocumentRequestResponse request)
        {
            return new InspectionDocument
            {
                InspectionDocumentId = request.InspectionDocumentId,
                UfReference = request.UfReference,
                SequentialCode = request.SequentialCode,
                DocumentNumber = request.DocumentNumber,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                StartDate = request.StartDate,
                UpdateDate = request.UpdateDate,
                EndDate = request.EndDate,
                JudgmentSectorId = request.JudgmentSectorId,
                InsDocSerialized = InsDocSerializedMapper.ConvertToObject(request.InsDocSerializedRequestResponses),
                InsDocServiceOrder = InsDocServiceOrderMapper.ConvertToObject(request.InsDocServiceOrderRequestResponses),
                InsDocEconomicAgent = InsDocEconomicAgentMapper.ConvertToObject(request.InsDocEconomicAgentRequestResponses),
                InsDocRepresentative = InsDocRepresentativeMapper.ConvertToObject(request.InsDocRepresentativeRequestResponses),
                InsDocInspectionAgentList = request.InsDocInspectionAgentRequestResponses?.Select(p => p.ConvertToObject()).ToList(),
                InsDocWitnessList = request.InsDocWitnessRequestResponses?.Select(p => p.ConvertToObject()).ToList(),
                InsDocTypificationList = request.InsDocTypificationRequestResponses?.Select(p => p.ConvertToObject()).ToList(),
                InsDocAttachmentList = request.InsDocAttachmentRequestResponses?.Select(p => p.ConvertRequestToObject()).ToList()
            };
        }

        public static InspectionDocumentReducedResponse ConvertObjectToResponseReduced(InspectionDocument inspectionDocument)
        {
            if (inspectionDocument == null) return null;

            return new InspectionDocumentReducedResponse
            {
                InspectionDocumentId = inspectionDocument.InspectionDocumentId,
                SequentialCode = inspectionDocument.SequentialCode,
                UpdateDate = inspectionDocument.UpdateDate
            };
        }

        public static InspectionDocument ConvertObjectUpdated(InspectionDocumentRequestResponse request, InspectionDocument original)
        {
            if (request == null) return null;

            original.UfReference = request.UfReference;
            original.SequentialCode = request.SequentialCode;
            original.DocumentNumber = request.DocumentNumber;
            original.Latitude = request.Latitude;
            original.Longitude = request.Longitude;
            original.StartDate = request.StartDate;
            original.UpdateDate = request.UpdateDate;
            original.EndDate = request.EndDate;
            original.JudgmentSectorId = request.JudgmentSectorId;
            original.InsDocSerialized = InsDocSerializedMapper.ConvertObjectUpdated(request.InsDocSerializedRequestResponses, original.InsDocSerialized);
            original.InsDocServiceOrder = InsDocServiceOrderMapper.ConvertObjectUpdated(request.InsDocServiceOrderRequestResponses, original.InsDocServiceOrder);
            original.InsDocEconomicAgent = InsDocEconomicAgentMapper.ConvertObjectUpdated(request.InsDocEconomicAgentRequestResponses, original.InsDocEconomicAgent);
            original.InsDocRepresentative = InsDocRepresentativeMapper.ConvertObjectUpdated(request.InsDocRepresentativeRequestResponses, original.InsDocRepresentative);
            original.InsDocInspectionAgentList = InsDocInspectionAgentMapper.ConvertObjectUpdatedList(request.InsDocInspectionAgentRequestResponses, original);
            original.InsDocWitnessList = InsDocWitnessMapper.ConvertObjectUpdatedList(request.InsDocWitnessRequestResponses, original);
            original.InsDocTypificationList = InsDocTypificationMapper.ConvertObjectUpdatedList(request.InsDocTypificationRequestResponses, original);
            original.InsDocAttachmentList = InsDocAttachmentMapper.ConvertObjectUpdatedList(request.InsDocAttachmentRequestResponses, original);

            return original;
        }
    }
}