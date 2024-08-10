using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class UserRolesServices : IUserRoles
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRolesServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(UserRole userRole)
        {
           await _unitOfWork.Repository<UserRole>().AddAsync(userRole);
           await _unitOfWork.SaveAsync();
        }

        public async Task<UserRole> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<UserRole>().Get(Id);
            res.State = StateEnum.deleted;
            await _unitOfWork.Repository<UserRole>().UpdateAsync(Id, res);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<IEnumerable<UserRole>> GetAll()
        {
          var res=  await _unitOfWork.Repository<UserRole>().GetAll();

            return res;
        }

        public async Task<UserRole> GetRolesByUserId(long userId)
        {
            var res = await _unitOfWork.Repository<UserRole>().Get(ur=>ur.UserId == userId);
            return res;
        }

        public async Task<UserRole> GetUserRolesByRoleId(long roleId)
        {
            var res = await _unitOfWork.Repository<UserRole>().Get(ur => ur.RoleId == roleId);
            return res;
        }

        public async Task<UserRole> Update(UserRole userRole)
        {
           var res = await _unitOfWork.Repository<UserRole>().UpdateAsync(userRole.Id, userRole);
           await _unitOfWork.SaveAsync();
            return res;
        }
    }
}
