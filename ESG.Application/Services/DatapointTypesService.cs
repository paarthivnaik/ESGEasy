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
    public class DatapointTypesService : IDatapointTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DatapointTypesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(DataPointTypes dataPointTypes)
        {
            await _unitOfWork.Repository<DataPointTypes>().AddAsync(dataPointTypes);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DataPointTypes>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DataPointTypes>> GetAll()
        {
            return await _unitOfWork.Repository<DataPointTypes>().GetAll();
        }

        public async Task<DataPointTypes> GetById(long Id)
        {
            return await _unitOfWork.Repository<DataPointTypes>().Get(Id);
        }

        public async Task<DataPointTypes> UpdateAsync(DataPointTypes dataPointTypes)
        {
            var res = await _unitOfWork.Repository<DataPointTypes>().Update(dataPointTypes);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

