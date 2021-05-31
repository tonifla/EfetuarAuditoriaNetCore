using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using System.Linq;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class NrUfMapper
    {
        public static NrUfResponse ConvertToResponse(this NrUf nrUf) => ConvertObjectToResponse(nrUf);

        public static NrUfResponse ConvertObjectToResponse(NrUf nrUf)
        {
            if (nrUf == null) return null;

            return new NrUfResponse
            {
                NrUfId = nrUf.NrUfId,
                Acronym = nrUf.Acronym,
                Name = nrUf.Name,
                Responsible = nrUf.Responsible,
                SubstituteResponsible = nrUf.SubstituteResponsible,
                Address = nrUf.Address,
                PlanningEmail = nrUf.PlanningEmail,
                ResultEmail = nrUf.ResultEmail,
                UfResponses = nrUf.UfList?.Select(p => p.ConvertToResponse()).ToList()
            };
        }

        internal static NrUf ConvertToObject(this NrUfResponse response)
        {
            return new NrUf
            {
                NrUfId = response.NrUfId,
                Acronym = response.Acronym,
                Name = response.Name,
                Responsible = response.Responsible,
                SubstituteResponsible = response.SubstituteResponsible,
                Address = response.Address,
                PlanningEmail = response.PlanningEmail,
                ResultEmail = response.ResultEmail,
                UfList = response.UfResponses?.Select(p => p.ConvertToObject()).ToList()
            };
        }
    }
}