using AutoMapper;
using ESG.Application.Dto.Get;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class GetTranslationsProfile : Profile
    {
        public GetTranslationsProfile()
        {
            //uom
            CreateMap<UnitOfMeasureTranslation, GetTranslationsResponseDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.TranslationsId, opt => opt.MapFrom(src => src.Id));
            //uomType
            CreateMap<UnitOfMeasureTypeTranslation, GetTranslationsResponseDto>()
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
              .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
              .ForMember(dest => dest.TranslationsId, opt => opt.MapFrom(src => src.Id));

            //Dimnesions
            CreateMap<DimensionTranslation, GetTranslationsResponseDto>()
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
              .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
              .ForMember(dest => dest.TranslationsId, opt => opt.MapFrom(src => src.Id));
            //DimensionType
            CreateMap<DimensionTypeTranslation, GetTranslationsResponseDto>()
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
              .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
              .ForMember(dest => dest.TranslationsId, opt => opt.MapFrom(src => src.Id));

            //DataPointValue
            CreateMap<DatapointValueTranslation, GetTranslationsResponseDto>()
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
              .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
              .ForMember(dest => dest.TranslationsId, opt => opt.MapFrom(src => src.Id));
            //DatapointType
            CreateMap<DatapointTypeTranslation, GetTranslationsResponseDto>()
              .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
              .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
              .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
              .ForMember(dest => dest.TranslationsId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
