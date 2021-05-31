using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InsDocAttachmentMapper
    {
        public static InsDocAttachmentRequestResponse ConvertToResponse(this InsDocAttachment insDocAttachment) => ConvertObjectToResponse(insDocAttachment);

        public static InsDocAttachmentRequestResponse ConvertObjectToResponse(InsDocAttachment insDocAttachment)
        {
            if (insDocAttachment == null) return null;

            return new InsDocAttachmentRequestResponse
            {
                InsDocAttachmentId = insDocAttachment.InsDocAttachmentId,
                InspectionDocumentId = insDocAttachment.InspectionDocumentId,
                Name = insDocAttachment.Name,
                AttachmentFile = insDocAttachment.AttachmentFile
            };
        }

        public static InsDocAttachment ConvertRequestToObject(this InsDocAttachmentRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new InsDocAttachment
            {
                InsDocAttachmentId = requestResponse.InsDocAttachmentId,
                InspectionDocumentId = requestResponse.InspectionDocumentId,
                Name = requestResponse.Name,
                AttachmentFile = requestResponse.AttachmentFile
            };
        }

        public static List<InsDocAttachment> ConvertObjectUpdatedList(List<InsDocAttachmentRequestResponse> request, InspectionDocument original)
        {
            original.InsDocAttachmentList.Clear();

            if (request != null) original.InsDocAttachmentList = request?.Select(p => p.ConvertRequestToObject()).ToList();

            return original.InsDocAttachmentList.ToList();
        }
    }
}