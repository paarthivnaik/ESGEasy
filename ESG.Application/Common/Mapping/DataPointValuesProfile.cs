using AutoMapper;
using ESG.Application.Dto.DatapointValue;
using ESG.Application.Dto.Dimension;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESG.Application.Common.Mapping
{
    internal class DataPointValueProfile : Profile
    {
        public DataPointValueProfile()
        {
            CreateMap<DataPointValue, DataPointValueResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.DatapointTypeId, opt => opt.MapFrom(src => src.DatapointTypeId))
                .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId))
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DisclosureRequirementId, opt => opt.MapFrom(src => src.DisclosureRequirementId))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.IsNarrative, opt => opt.MapFrom(src => src.IsNarrative));
            CreateMap<DataPointValueResponseDto, DataPointValue> ()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortText, opt => opt.MapFrom(src => src.ShortText))
                .ForMember(dest => dest.LongText, opt => opt.MapFrom(src => src.LongText))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.DatapointTypeId, opt => opt.MapFrom(src => src.DatapointTypeId))
                .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId))
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DisclosureRequirementId, opt => opt.MapFrom(src => src.DisclosureRequirementId))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.IsNarrative, opt => opt.MapFrom(src => src.IsNarrative));

            CreateMap<DatapointValueCreateRequestDto, DataPointValue>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DatapointTypeId, opt => opt.MapFrom(src => src.DatapointTypeId))
                .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId))
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DisclosureRequirementId, opt => opt.MapFrom(src => src.DisclosureRequirementId))
                .ForMember(dest => dest.IsNarrative, opt => opt.MapFrom(src => src.IsNarrative));

        }
    }
}
