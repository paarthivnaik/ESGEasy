using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DatapointValue;
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
        private readonly IMapper _mapper;
        public DatapointValuesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(DatapointValueCreateRequestDto dataPointValues)
        {
            var list = _mapper.Map<DataPointValues>(dataPointValues);
            await _unitOfWork.Repository<DataPointValues>().AddAsync(list);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DataPointValues>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DatapointValuesResponseDto>> GetAll()
        {
            var datapointValues = await _unitOfWork.Repository<DataPointValues>().GetAll();
            var list = _mapper.Map<IEnumerable<DatapointValuesResponseDto>>(datapointValues);
            return list;
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

