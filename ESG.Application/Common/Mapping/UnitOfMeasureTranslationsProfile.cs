using AutoMapper;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UOMTranslations;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class UnitOfMeasureTranslationsProfile : Profile
    {
        public UnitOfMeasureTranslationsProfile()
        {
            //Create
            CreateMap<UnitOfMeasureCreateRequestDto, UnitOfMeasureTranslations>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                 .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId));
            CreateMap<UnitOfMeasureTranslations, UnitOfMeasureCreateRequestDto>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId));
            CreateMap<UOMTranslationsCreateRequestDto, UnitOfMeasureTranslations>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));

            //Update
            CreateMap<UnitOfMeasureUpdateRequestDto, UnitOfMeasureTranslations>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
            .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
             .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<UnitOfMeasureTranslations, UnitOfMeasureUpdateRequestDto>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //get in Responce
            CreateMap<UnitOfMeasureTranslations, UnitOfMeasureResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<UnitOfMeasureResponseDto, UnitOfMeasureTranslations>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
            .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));


        }
    }
}
