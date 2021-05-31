using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class UorgMapper
    {
        public static UorgResponse ConvertToResponse(this Uorg uorg) => ConvertObjectToResponse(uorg);

        public static UorgResponse ConvertObjectToResponse(Uorg uorg)
        {
            if (uorg == null) return null;

            return new UorgResponse
            {
                UorgId = uorg.UorgId,
                Name = uorg.Name,
                Acronym = uorg.Acronym,
                InspectionProcedureList = uorg.InspectionProcedureList?.Select(p => p.ConvertToResponse()).ToList()
            };
        }

        internal static Uorg ConvertToObject(this UorgResponse response)
        {
            return new Uorg
            {
                UorgId = response.UorgId,
                Name = response.Name,
                Acronym = response.Acronym,
                InspectionProcedureList = response.InspectionProcedureList?.Select(p => p.ConvertToObject()).ToList()
            };
        }
    }
}