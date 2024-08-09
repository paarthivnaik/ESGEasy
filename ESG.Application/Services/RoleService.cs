using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.Tenants;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Role role)
        {
            await _unitOfWork.Repository<Role>().AddAsync(role);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<Role>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _unitOfWork.Repository<Role>().GetAll();
        }

        public async  Task<Role> GetById(long Id)
        {
            return await _unitOfWork.Repository<Role>().Get(Id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var res = await _unitOfWork.Repository<Role>().Update(role);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}
