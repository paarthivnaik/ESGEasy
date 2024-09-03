using AutoMapper;
using ESG.Application.Dto.Dimensions;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class DimensionTranslationsProfile  : Profile
    {
        public DimensionTranslationsProfile()
        {
            //create
            CreateMap<DimensionsCreateRequestDto, DimensionTranslations>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DimensionsId, opt => opt.MapFrom(src => src.DimensionsId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<DimensionTranslations, DimensionsCreateRequestDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.DimensionsId, opt => opt.MapFrom(src => src.DimensionsId))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //response
            CreateMap<DimensionsResponseDto, DimensionTranslations>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<DimensionTranslations, DimensionsResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
        }
    }
}
