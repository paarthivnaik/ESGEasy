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
    public class DatapointValuesService : IDatapointValuesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DatapointValuesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DataPointValues> AddAsync(DataPointValues dataPointValues)
        {
            var res = await _unitOfWork.Repository<DataPointValues>().AddAsync(dataPointValues);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DataPointValues>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DataPointValues>> GetAll()
        {
            return await _unitOfWork.Repository<DataPointValues>().GetAll();
        }

        public async Task<DataPointValues> GetById(long Id)
        {
            return await _unitOfWork.Repository<DataPointValues>().Get(Id);
        }

        public async Task<DataPointValues> UpdateAsync(DataPointValues dataPointValues)
        {
            var res = await _unitOfWork.Repository<DataPointValues>().Update(dataPointValues);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

