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
    public class UnitOfMeasureTypeService : IUnitOfMeasureTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfMeasureTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UnitOfMeasureType> AddAsync(UnitOfMeasureType unitOfMeasureType)
        {
            var res = await _unitOfWork.Repository<UnitOfMeasureType>().AddAsync(unitOfMeasureType);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<UnitOfMeasureType>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<UnitOfMeasureType>> GetAll()
        {
            return await _unitOfWork.Repository<UnitOfMeasureType>().GetAll();
        }

        public async Task<UnitOfMeasureType> GetById(long Id)
        {
            return await _unitOfWork.Repository<UnitOfMeasureType>().Get(Id);
        }

        public async Task<UnitOfMeasureType> UpdateAsync(UnitOfMeasureType unitOfMeasureType)
        {
            var res = await _unitOfWork.Repository<UnitOfMeasureType>().Update(unitOfMeasureType);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}
