using AutoMapper;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UOMTranslations;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class UnitOfMeasureTranslationProfile : Profile
    {
        public UnitOfMeasureTranslationProfile()
        {
            //Create
            CreateMap<UnitOfMeasureCreateRequestDto, UnitOfMeasureTranslation>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                 .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                 .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId));
            CreateMap<UnitOfMeasureTranslation, UnitOfMeasureCreateRequestDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.LastModifiedBy))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId));

            CreateMap<UOMTranslationsCreateRequestDto, UnitOfMeasureTranslation>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                 .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                 .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            //Update
            CreateMap<UnitOfMeasureUpdateRequestDto, UnitOfMeasureTranslation>()
            .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
            .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
             .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<UnitOfMeasureTranslation, UnitOfMeasureUpdateRequestDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //get in Responce
            CreateMap<UnitOfMeasureTranslation, UnitOfMeasureResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<UnitOfMeasureResponseDto, UnitOfMeasureTranslation>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
            .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));


        }
    }
}
