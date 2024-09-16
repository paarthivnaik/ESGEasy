using AutoMapper;
using ESG.Application.Dto.Currency;
using ESG.Application.Dto.User;
using ESG.Domain.Entities.DomainEntities;
using ESG.Domain.Entities.TenantAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreationRequestDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id ))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName ?? "DefaultFirstName"))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName ?? "DefaultLastName"))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password ?? "Defaultpassword"))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber ?? "Defaultphonenumber"))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId ))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email ?? "DefaultEmail"));
        }
    }
}
