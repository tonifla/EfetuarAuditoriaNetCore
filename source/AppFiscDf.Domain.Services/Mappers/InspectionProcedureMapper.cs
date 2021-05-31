using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class InspectionProcedureMapper
    {
        public static InspectionProcedureResponse ConvertToResponse(this InspectionProcedure inspectionProcedure) => ConvertObjectToResponse(inspectionProcedure);

        public static InspectionProcedureResponse ConvertObjectToResponse(InspectionProcedure inspectionProcedure)
        {
            if (inspectionProcedure == null) return null;

            return new InspectionProcedureResponse
            {
                InspectionProcedureId = inspectionProcedure.InspectionProcedureId,
                UorgId = inspectionProcedure.UorgId,
                Text = inspectionProcedure.Text,
                Sort = inspectionProcedure.Sort,
                TypificationList = inspectionProcedure.TypificationList?.Select(p => p.ConvertToResponse()).ToList()
            };
        }

        internal static InspectionProcedure ConvertToObject(this InspectionProcedureResponse response)
        {
            return new InspectionProcedure
            {
                InspectionProcedureId = response.InspectionProcedureId,
                UorgId = response.UorgId,
                Text = response.Text,
                Sort = response.Sort,
                TypificationList = response.TypificationList?.Select(p => p.ConvertToObject()).ToList()
            };
        }
    }
}