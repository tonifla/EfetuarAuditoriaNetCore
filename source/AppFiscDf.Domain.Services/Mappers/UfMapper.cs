using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class UfMapper
    {
        public static UfResponse ConvertToResponse(this Uf uf) => ConvertObjectToResponse(uf);

        public static UfResponse ConvertObjectToResponse(Uf uf)
        {
            if (uf == null) return null;

            return new UfResponse
            {
                UfAcronym = uf.UfAcronym,
                NrUfId = uf.NrUfId,
                Name = uf.Name,
                UfReference = uf.UfReference
            };
        }

        internal static Uf ConvertToObject(this UfResponse response)
        {
            return new Uf
            {
                UfAcronym = response.UfAcronym,
                NrUfId = response.NrUfId,
                Name = response.Name,
                UfReference = response.UfReference
            };
        }
    }
}