using AutoMapper;
using ESG.Application.Dto.Dimensions;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class DimensionsProfile : Profile
    {
        public DimensionsProfile()
        {
            //create
            CreateMap<DimensionsCreateRequestDto, Dimensions>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DimensionTypeId, opt => opt.MapFrom(src => src.DimentionTypeId))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationaId))
                .ForMember(dest => dest.isHierarchical, opt => opt.MapFrom(src => src.isHierarchical))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
            CreateMap<Dimensions, DimensionsCreateRequestDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.DimentionTypeId, opt => opt.MapFrom(src => src.DimensionTypeId))
               .ForMember(dest => dest.OrganizationaId, opt => opt.MapFrom(src => src.OrganizationId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.isHierarchical, opt => opt.MapFrom(src => src.isHierarchical))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));

            //response
            CreateMap<Dimensions, DimensionsResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
               .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
               .ForMember(dest => dest.isHierarchical, opt => opt.MapFrom(src => src.isHierarchical))
               .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId));
        }
    }
}
