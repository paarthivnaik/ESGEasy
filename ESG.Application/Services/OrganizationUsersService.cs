using AutoMapper;
using ESG.Application.Common.Interface;
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
    public class OrganizationUsersService : IOrganizationUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationUsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(OrganizationUser organizationUsers)
        {
            await _unitOfWork.Repository<OrganizationUser>().AddAsync(organizationUsers);
            await _unitOfWork.SaveAsync();
        }

        public async Task<long> Count()
        {
            return await _unitOfWork.Repository<OrganizationUser>().Count();
        }

        public async Task<OrganizationUser> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<OrganizationUser>().Get(Id);
            res.State = StateEnum.deleted;
            await _unitOfWork.Repository<OrganizationUser>().UpdateAsync(Id, res);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<IEnumerable<OrganizationUser>> GetAll()
        {
            return await _unitOfWork.Repository<OrganizationUser>().GetAll();
        }

        public async Task<OrganizationUser> GetById(long Id)
        {
            return await _unitOfWork.Repository<OrganizationUser>().Get(Id);
        }

        public async Task<OrganizationUser> UpdateAsync(OrganizationUser organizationUsers)
        {
            var res = await _unitOfWork.Repository<OrganizationUser>().UpdateAsync(organizationUsers.Id, organizationUsers);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}
