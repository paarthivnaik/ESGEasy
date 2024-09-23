using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DatapointValue;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities.DomainEntities;
using ESG.Domain.Entities.Hierarchies;
using Microsoft.VisualBasic;
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
        private readonly IHierarchyService _hierarchyService;

        private readonly IMapper _mapper;
        public DatapointValuesService(IUnitOfWork unitOfWork, IHierarchyService hierarchyService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hierarchyService = hierarchyService;
            _mapper = mapper;
        }

        public async Task AddAsync(List<DatapointValueCreateRequestDto> dataPointValues)
        {
            var oldDatapoints = new List<DataPointValues>();
            var newDatapoints = new List<DataPointValues>();
            if (dataPointValues != null)
            {
                foreach (var datapoint in dataPointValues)
                {
                    if (dataPointValues != null && datapoint.DatapointId > 0)
                    {
                        var existingdatapoint = await _unitOfWork.Repository<DataPointValues>().Get(a => a.Id == datapoint.DatapointId);
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
                        //var newDP = new DataPointValues{
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
                        //};
                        var newDP = _mapper.Map<DataPointValues>(datapoint);
                        newDatapoints.Add(newDP);
                        
                    }
                }
            }
            await _unitOfWork.Repository<DataPointValues>().UpdateRange(oldDatapoints);
            await _unitOfWork.Repository<DataPointValues>().AddRange(newDatapoints);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDatapoint(long id)
        {
            var dataPoint = await _unitOfWork.Repository<DataPointValues>().Get(uom => uom.Id == id);
            if (dataPoint == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {dataPoint.Id} not found.");
            }
            dataPoint.State = Domain.Entities.StateEnum.deleted;
            await _unitOfWork.Repository<DataPointValues>().Update(dataPoint);
            await _unitOfWork.SaveAsync();
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

