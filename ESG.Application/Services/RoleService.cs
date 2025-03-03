using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.Tenants;
using ESG.Application.Dto.Organization;
using ESG.Application.Dto.Roles;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task AddAsync(RoleCreationRequestDto role)
        {   
            Role newRole = new Role();
            if (role != null)
            {
                newRole.Name = role.Name;
            }
            await _unitOfWork.Repository<Role>().AddAsync(newRole);
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

        public async Task UpdateAsync(RoleCreationRequestDto role)
        {
            if (role.Id > 0)
            {
                var existingRole = await _unitOfWork.Repository<Role>().Get(role.Id);
                if (existingRole != null)
                {
                    existingRole.Name = role.Name;                    
                    var res = await _unitOfWork.Repository<Role>().UpdateAsync(role.Id, existingRole);
                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    throw new System.Exception("Role does not exist");
                }
            }
           
        }
    }
}
