using AutoMapper;
using ESG.Application.Dto.Currency;
using ESG.Application.Dto.DisclosureRequirement;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.CurrencyCode));
        }
    }
}
