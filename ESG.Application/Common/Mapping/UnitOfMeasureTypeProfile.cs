using AutoMapper;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class UnitOfMeasureTypeProfile : Profile
    {
        public UnitOfMeasureTypeProfile()
        {
            //create
            CreateMap<UnitOfMeasureTypeCreateRequestDto, UnitOfMeasureType>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));

            //update
            CreateMap<UnitOfMeasureTypeUpdateRequestDto, UnitOfMeasureType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                //.ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));

            //response
            CreateMap<UnitOfMeasureType, UnitOfMeasureTypeResponseDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy));

        }
    }
}
