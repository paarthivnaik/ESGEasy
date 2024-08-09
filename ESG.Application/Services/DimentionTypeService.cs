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
    public class DimentionTypeService : IDimentionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DimentionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DimensionType> AddAsync(DimensionType dimentionType)
        {
            var res = await _unitOfWork.Repository<DimensionType>().AddAsync(dimentionType);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DimensionType>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DimensionType>> GetAll()
        {
            return await _unitOfWork.Repository<DimensionType>().GetAll();
        }

        public async Task<DimensionType> GetById(long Id)
        {
            return await _unitOfWork.Repository<DimensionType>().Get(Id);
        }

        public async Task<DimensionType> UpdateAsync(DimensionType dimentionType)
        {
            var res = await _unitOfWork.Repository<DimensionType>().Update(dimentionType);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}
