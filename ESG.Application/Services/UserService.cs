using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Jwt;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> Create(UserDto userDto)
        {
            var user= new User();
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.PhoneNumber;
            user.LanguageId= userDto.LanguageId;
            user.SecurityStamp= Guid.NewGuid();
            user.Password= Crypto.GenerateHash(userDto.Password, user.SecurityStamp.ToString());
            user.Email = userDto.Email.ToLowerInvariant();
            var res= await _unitOfWork.Repository<User>().AddAsync(user);
            await _unitOfWork.SaveAsync();
            return res.Id;
            
        }

        public Task<User> GetUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePassword(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
