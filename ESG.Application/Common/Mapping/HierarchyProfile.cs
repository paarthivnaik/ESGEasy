using AutoMapper;
using ESG.Application.Dto.Dimension;
using ESG.Application.Dto.Hierarchy;
using ESG.Domain.Models;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class HierarchyProfile : Profile
    {
        public HierarchyProfile()
        {
            //for getting heirarchyrelateddata
            CreateMap<Topic, HeirarchyDataResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText));

            CreateMap<Standard, HeirarchyDataResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText));

            CreateMap<DisclosureRequirement, HeirarchyDataResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText));

            CreateMap<DataPointValue, HeirarchyDataResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText));

            ////for hierarchydata
            //CreateMap<Hierarchy, HierarchyResponseDto>()
            //    .ForMember(dest => dest.HierarchyId, opt => opt.MapFrom(src => src.HierarchyId))
            //    .ForMember(dest => dest.DatapointId, opt => opt.MapFrom(src => src.DataPointValueId));
        }
    }
}
