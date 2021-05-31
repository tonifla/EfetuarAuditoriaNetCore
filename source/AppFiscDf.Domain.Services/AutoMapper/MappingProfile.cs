using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AutoMapper;

namespace AppFiscDf.Domain.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Uorg, UorgResponse>()
                .ForMember(dest => dest.InspectionProcedureList, opt => opt.MapFrom(src => src.InspectionProcedureList));

            CreateMap<InspectionProcedure, InspectionProcedureResponse>()
                .ForMember(dest => dest.TypificationList, opt => opt.MapFrom(src => src.TypificationList));

            CreateMap<Typification, TypificationResponse>()
                .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity));

            CreateMap<Activity, ActivityResponse>();

            CreateMap<Uf, UfResponse>();

            CreateMap<NrUf, NrUfResponse>()
                .ForMember(dest => dest.UfResponses, opt => opt.MapFrom(src => src.UfList));
        }
    }
}