using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;

namespace AppFiscDf.Domain.Services.Mappers
{
    public static class JudgmentSectorMapper
    {
        public static JudgmentSector ConvertToObject(this JudgmentSectorRequestResponse requestResponse)
        {
            if (requestResponse == null) return null;

            return new JudgmentSector
            {
                JudgmentSectorId = requestResponse.JudgmentSectorId,
                Acronym = requestResponse.Acronym,
                Name = requestResponse.Name,
                Address = requestResponse.Address
            };
        }

        public static JudgmentSectorRequestResponse ConvertToRequestResponse(this JudgmentSector judgmentSector)
        {
            if (judgmentSector == null) return null;

            return new JudgmentSectorRequestResponse
            {
                JudgmentSectorId = judgmentSector.JudgmentSectorId,
                Acronym = judgmentSector.Acronym,
                Name = judgmentSector.Name,
                Address = judgmentSector.Address
            };
        }

        public static JudgmentSector ConvertObjectUpdated(JudgmentSectorRequestResponse request, JudgmentSector original)
        {
            if (request == null) return null;

            original.JudgmentSectorId = request.JudgmentSectorId;
            original.Acronym = request.Acronym;
            original.Name = request.Name;
            original.Address = request.Address;

            return original;
        }
    }
}