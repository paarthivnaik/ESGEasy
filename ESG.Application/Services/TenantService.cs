using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;

namespace ESG.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TenantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Tenant tenant)
        {
           await _unitOfWork.Repository<Tenant>().AddAsync(tenant);
           await _unitOfWork.SaveAsync();
        }

        public Task<long> Count()
        {
            throw new NotImplementedException();
        }

        public Task<Tenant> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tenant>> GetAll()
        {
            return await _unitOfWork.Repository<Tenant>().GetAll();
        }

        public async Task<Tenant> GetById(long Id)
        {
            return await _unitOfWork.Repository<Tenant>().Get(Id);
        }

        public async Task<Tenant> UpdateAsync(Tenant tenant)
        {
            var res= await _unitOfWork.Repository<Tenant>().UpdateAsync(tenant.Id, tenant);
            await _unitOfWork.SaveAsync();
            return res;

        }
    }
}
