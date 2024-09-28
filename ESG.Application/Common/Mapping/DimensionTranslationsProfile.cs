using AutoMapper;
using ESG.Application.Dto.Dimension;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class DimensionTranslationProfile  : Profile
    {
        public DimensionTranslationProfile()
        {
            //create
            CreateMap<DimensionCreateRequestDto, DimensionTranslation>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DimensionsId, opt => opt.MapFrom(src => src.DimensionId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<DimensionTranslation, DimensionCreateRequestDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.DimensionId, opt => opt.MapFrom(src => src.DimensionsId))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //response
            CreateMap<DimensionResponseDto, DimensionTranslation>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<DimensionTranslation, DimensionResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
        }
    }
}
