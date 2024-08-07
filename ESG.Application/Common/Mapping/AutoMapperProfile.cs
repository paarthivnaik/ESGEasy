﻿using AutoMapper;
using ESG.Application.Dto;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UnitOfMeasureDto, UnitOfMeasure>()
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.UnitOfMeasureTypeId, opt => opt.MapFrom(src => src.UnitOfMeasureTypeId))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId));

            CreateMap<UnitOfMeasure, UnitOfMeasureDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UnitOfMeasureTypeId, opt => opt.MapFrom(src => src.UnitOfMeasureTypeId))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId));
           
            CreateMap<UnitOfMeasureDto, UnitOfMeasureTranslations>()
            .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
            .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
             .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId))
             .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId));
            CreateMap<UnitOfMeasureTranslations, UnitOfMeasureDto>()
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId))
               .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId));

        }
    }
}
