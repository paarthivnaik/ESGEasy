using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Jwt;
using ESG.Application.Dto.User;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<User> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<User>().Get(Id);
            res.State = StateEnum.deleted;
            await _unitOfWork.Repository<User>().UpdateAsync(Id, res);
            await _unitOfWork.SaveAsync();
            return res;
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllUsers()
        {
            var users = await _unitOfWork.Repository<User>().GetAll();
            var response = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return response;
        }
        public async Task<UserResponseDto> GetUserById(long userId)
        {
            var user = await _unitOfWork.Repository<User>().Get(userId);
            if (user == null)
            {
                throw new System.Exception("User not found");
            }
            var response = _mapper.Map<UserResponseDto>(user);
            return response;
        }
        public async Task<List<long>> GetUserOrganizations(long userId)
        {
            var userOrganizations = await _unitOfWork.Repository<OrganizationUser>()
                .GetAll(orgUser => orgUser.UserId == userId);

            if (userOrganizations == null || !userOrganizations.Any())
            {
                throw new System.Exception("User not found or not associated with any organizations");
            }

            var response = userOrganizations.Select(orgUser => orgUser.OrganizationId).ToList();

            return response;
        }

        public async Task<UserDetailsResponeDto> GetUserDetails(long userId)
        {
            var user = await _unitOfWork.UsersRepo.GetUserDetails(userId);
            if (user == null)
            {
                throw new System.Exception("User not found");
            }
            var organizationUser = user.OrganizationUsers.FirstOrDefault();
            if (organizationUser == null)
            {
                throw new System.Exception("User is not associated with the specified organization");
            }
            var response = new UserDetailsResponeDto
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleId = user.UserRole.RoleId,
                OrganizationId = organizationUser.OrganizationId
            };
            return response;
        }
        public async Task Create(UserCreationRequestDto userDto)
        {
            var user = new User();
            user = _mapper.Map<User>(userDto);
            user.SecurityStamp = Guid.NewGuid();
            //user.Password= Crypto.GenerateHash(userDto.Password, user.SecurityStamp.ToString());
            user.Email = userDto.Email;
            await _unitOfWork.Repository<User>().AddAsync(user);
            await _unitOfWork.SaveAsync();
        }
        public async Task<string> UserLogin(UserLogInRequestDto userLogInRequestDto)
        {
            var validUser = await _unitOfWork.Repository<User>().Get(a => a.Email == userLogInRequestDto.Email && a.Password == userLogInRequestDto.Password);
            if (validUser == null)
            {
                throw new System.Exception("User not valid, please enter valid credentials");
            }
            var user = await GetUserDetails(validUser.Id);
            var token = await _unitOfWork.UsersRepo.GenerateToken(user.UserId, user.Email, user.OrganizationId, user.RoleId.Value);
            return token.ToString();
        }
        public Task<User> Update(UserCreationRequestDto user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePassword(UserCreationRequestDto user)
        {
            throw new NotImplementedException();
        }
    }
}
