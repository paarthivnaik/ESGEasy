using AutoMapper;
using ESG.Application.Dto.DatapointValue;
using ESG.Application.Dto.DisclosureRequirement;
using ESG.Domain.Entities.Hierarchies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class DisclosureRequirementProfile : Profile
    {
        public DisclosureRequirementProfile()
        {
            CreateMap<DisclosureRequirement, DisclosureRequirementResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.StandardId, opt => opt.MapFrom(src => src.StandardId));
        }
    }
}
