using AutoMapper;
using ESG.Application.Dto.Dimension;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class DimensionProfile : Profile
    {
        public DimensionProfile()
        {
            //create
            CreateMap<DimensionCreateRequestDto, Dimension>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DimensionTypeId, opt => opt.MapFrom(src => src.DimensionTypeId))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<Dimension, DimensionCreateRequestDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.DimensionTypeId, opt => opt.MapFrom(src => src.DimensionTypeId))
               .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //response
            CreateMap<Dimension, DimensionResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
        }
    }
}
