using AutoMapper;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Dto.UOMTypeTranslations;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class UnitOfMeasureProfile : Profile
    {
        public UnitOfMeasureProfile()
        {
            //create
            CreateMap<UnitOfMeasureCreateRequestDto, UnitOfMeasure>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UnitOfMeasureTypeId, opt => opt.MapFrom(src => src.UnitOfMeasureTypeId));
            CreateMap<UnitOfMeasure, UnitOfMeasureCreateRequestDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.UnitOfMeasureTypeId, opt => opt.MapFrom(src => src.UnitOfMeasureTypeId));
           
            //update
            CreateMap<UnitOfMeasureUpdateRequestDto, UnitOfMeasure>()
                //.ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));
            CreateMap<UnitOfMeasure, UnitOfMeasureUpdateRequestDto>()
               // .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy));
            
            //get in Response
            CreateMap<UnitOfMeasureResponseDto, UnitOfMeasure>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId));
            CreateMap<UnitOfMeasure, UnitOfMeasureResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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
