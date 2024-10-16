using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Dto.DatapointValue;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using ESG.Domain.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DataPointValueService : IDataPointValueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatapointValueRepo _datapointValueRepo;

        private readonly IMapper _mapper;
        public DataPointValueService(IUnitOfWork unitOfWork, IDatapointValueRepo datapointValueRepo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _datapointValueRepo = datapointValueRepo;
            _mapper = mapper;
        }

        public async Task AddAsync(List<DatapointValueCreateRequestDto> DataPointValue)
        {
            var oldDatapoints = new List<DataPointValue>();
            var newDatapoints = new List<DataPointValue>();
            if (DataPointValue != null)
            {
                foreach (var datapoint in DataPointValue)
                {
                    if (DataPointValue != null && datapoint.DatapointId > 0)
                    {
                        var existingdatapoint = await _unitOfWork.Repository<DataPointValue>().Get(a => a.Id == datapoint.DatapointId);
                        existingdatapoint.Name = datapoint.Name;
                        existingdatapoint.DatapointTypeId = datapoint.DatapointTypeId;
                        existingdatapoint.UnitOfMeasureId = datapoint.UnitOfMeasureId;
                        existingdatapoint.CurrencyId = datapoint.CurrencyId;
                        existingdatapoint.IsNarrative = datapoint.IsNarrative;
                        existingdatapoint.Purpose = datapoint.Purpose;
                        existingdatapoint.LanguageId = datapoint.LanguageId;
                        existingdatapoint.DisclosureRequirementId = datapoint.DisclosureRequirementId;
                        oldDatapoints.Add(existingdatapoint);
                    }
                    else
                    {
                        //var newDP = new DataPointValue
                        //{
                        //    Name = datapoint.Name,
                        //    Code = datapoint.Code,
                        //    DatapointTypeId = datapoint.DatapointTypeId,
                        //    UnitOfMeasureId = datapoint.UnitOfMeasureId,
                        //    CurrencyId = datapoint.CurrencyId,
                        //    IsNarrative = datapoint.IsNarrative,
                        //    Purpose = datapoint.Purpose,
                        //    LanguageId = datapoint.LanguageId,
                        //    OrganizationId = datapoint.OrganizationId,
                        //    CreatedBy = datapoint.UserId,
                        //    LastModifiedBy = datapoint.UserId,
                        //    CreatedDate = DateTime.UtcNow,
                        //    LastModifiedDate = DateTime.UtcNow,
                        //    DisclosureRequirementId = datapoint.DisclosureRequirementId,
                        //    State = Domain.Enum.StateEnum.active,
                        //};
                        var existingdatapointCode = await _unitOfWork.Repository<DataPointValue>().Get(a => a.Code == datapoint.Code);
                        if (existingdatapointCode != null)
                        {
                            throw new System.Exception($"The Datapoint with code - {datapoint.Code} alredy exists");
                        }
                        var newDP = _mapper.Map<DataPointValue>(datapoint);
                        newDP.State = Domain.Enum.StateEnum.active;
                        newDatapoints.Add(newDP);
                        
                    }
                }
            }
            await _unitOfWork.Repository<DataPointValue>().UpdateRange(oldDatapoints);
            await _unitOfWork.Repository<DataPointValue>().AddRange(newDatapoints);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDatapoint(DatapointValueDeleteRequestDto datapointValueDeleteRequestDto)
        {
            var dataPoint = await _unitOfWork.Repository<DataPointValue>().Get(uom => uom.Id == datapointValueDeleteRequestDto.DatapointId);
            if (dataPoint == null)
            {
                throw new KeyNotFoundException($"Datapoint with ID {dataPoint.Id} not found.");
            }
            dataPoint.State = datapointValueDeleteRequestDto.State;
            await _unitOfWork.Repository<DataPointValue>().Update(dataPoint);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DataPointValueResponseDto>> GetAll(long organizationId)
        {
            var datapoints = await _unitOfWork.DatapointValueRepo.GetAllDatapointValues(organizationId);
            var list = _mapper.Map<IEnumerable<DataPointValueResponseDto>>(datapoints);
            return list;
        }

        public async Task<DataPointValue> GetById(long Id)
        {
            return await _unitOfWork.Repository<DataPointValue>().Get(Id);
        }


        public async Task<DataPointValue> UpdateAsync(DataPointValue DataPointValue)
        {
            var res = await _unitOfWork.Repository<DataPointValue>().Update(DataPointValue);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

