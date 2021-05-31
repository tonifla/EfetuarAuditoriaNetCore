using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class TypificationMapper
    {
        public static TypificationResponse ConvertToResponse(this Typification typification) => ConvertObjectToResponse(typification);

        public static TypificationResponse ConvertObjectToResponse(Typification typification)
        {
            if (typification == null) return null;

            return new TypificationResponse
            {
                TypificationId = typification.TypificationId,
                ActivityId = typification.ActivityId,
                InspectionProcedureId = typification.InspectionProcedureId,
                Title = typification.Title,
                Model = typification.Model,
                JsonInput = typification.JsonInput,
                HTMLInput = typification.HTMLInput
            };
        }

        internal static Typification ConvertToObject(this TypificationResponse response)
        {
            return new Typification
            {
                TypificationId = response.TypificationId,
                ActivityId = response.ActivityId,
                InspectionProcedureId = response.InspectionProcedureId,
                Title = response.Title,
                Model = response.Model,
                JsonInput = response.JsonInput,
                HTMLInput = response.HTMLInput
            };
        }
    }
}