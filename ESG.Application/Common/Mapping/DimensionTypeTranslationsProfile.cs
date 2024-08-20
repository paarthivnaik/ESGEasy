using AutoMapper;
using ESG.Application.Dto.Dimensions;
using ESG.Application.Dto.DimensionTypes;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class DimensionTypeTranslationsProfile : Profile
    {
        public DimensionTypeTranslationsProfile()
        {
            //create
            CreateMap<DimensionTypeCreateRequestDto, DimensionTypeTranslations>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<DimensionTypeTranslations, DimensionsCreateRequestDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //response
            CreateMap<DimensionTypeResponseDto, DimensionTypeTranslations>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<DimensionTypeTranslations, DimensionTypeResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
        }
    }
}
