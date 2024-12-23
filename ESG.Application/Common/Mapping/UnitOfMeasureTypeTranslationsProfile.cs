﻿using AutoMapper;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Dto.UOMTypeTranslations;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class UnitOfMeasureTypeTranslationsProfile : Profile
    {
        public UnitOfMeasureTypeTranslationsProfile()
        {
            //create
            CreateMap<UnitOfMeasureTypeCreateRequestDto, UnitOfMeasureTypeTranslation>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.UnitOfMeasureTypeId, opt => opt.MapFrom(src => src.UnitOfMeasureTypeId));

            CreateMap<UOMTypeTranslationsCreateRequestDto, UnitOfMeasureTypeTranslation>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));


            //response
            CreateMap<UnitOfMeasureTypeTranslation, UnitOfMeasureTypeResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy));
            CreateMap<UnitOfMeasureTypeResponseDto, UnitOfMeasureTypeTranslation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));


        }
    }
}
