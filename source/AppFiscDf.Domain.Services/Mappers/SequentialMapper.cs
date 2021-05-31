using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class SequentialMapper
    {
        public static SequentialRequestResponse ConvertToRequestResponse(this Sequential sequential) => ConvertObjectToResponse(sequential);

        public static SequentialRequestResponse ConvertObjectToResponse(Sequential sequential)
        {
            if (sequential == null) return null;

            return new SequentialRequestResponse
            {
                InspectionAgentId = sequential.InspectionAgentId,
                SequentialCode = sequential.SequentialCode
            };
        }

        public static Sequential ConvertRequestToObject(decimal inspectionAgentId, decimal sequentialCode)
        {
            return new Sequential
            {
                InspectionAgentId = inspectionAgentId,
                SequentialCode = sequentialCode
            };
        }
    }
}