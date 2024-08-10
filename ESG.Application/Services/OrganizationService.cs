using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;

namespace ESG.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Organization organization)
        {
            await _unitOfWork.Repository<Organization>().AddAsync(organization);
        }

        public async Task<long> Count()
        {
           return await _unitOfWork.Repository<Organization>().Count();
        }

        public async Task<Organization> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<Organization>().Get(Id);
            res.IsActive = false;
            await _unitOfWork.Repository<Organization>().UpdateAsync(Id, res);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<IEnumerable<Organization>> GetAll()
        {
            var res = await _unitOfWork.Repository<Organization>().GetAll();
            return res;
        }

        public async Task<Organization> GetById(long Id)
        {
           var res = await _unitOfWork.Repository<Organization>().Get(Id);
            return res;
        }

        public async Task<Organization> UpdateAsync(Organization organization)
        {
            var res = await _unitOfWork.Repository<Organization>().UpdateAsync(organization.Id, organization);
            return res;
        }
    }
}
