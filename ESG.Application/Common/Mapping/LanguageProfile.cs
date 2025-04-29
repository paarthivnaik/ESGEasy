using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESG.Application.Dto.Dimension;
using ESG.Application.Dto.Language;
using ESG.Domain.Models;

namespace ESG.Application.Common.Mapping
{
    public class LanguageProfile :Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, LanguageDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsoCode, opt => opt.MapFrom(src => src.IsoCode));                
        }
    }
}
