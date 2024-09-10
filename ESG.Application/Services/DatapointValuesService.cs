using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DatapointValue;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
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

        public async Task AddAsync(DatapointValueCreateRequestDto dataPointValues)
        {
            var datapoint = new DataPointValues();
            if (dataPointValues != null && dataPointValues.Id > 0)
            {
                var existingdatapoint = await _unitOfWork.Repository<DataPointValues>().Get(a => a.Id == dataPointValues.Id);
                existingdatapoint.Name = dataPointValues.Name;
                existingdatapoint.DatapointTypeId = dataPointValues.DatapointTypeId;
                existingdatapoint.UnitOfMeasureId = dataPointValues.UnitOfMeasureId;
                existingdatapoint.CurrencyId = dataPointValues.CurrencyId;
                existingdatapoint.IsNarrative = dataPointValues.IsNarrative;
                existingdatapoint.Purpose = dataPointValues.Purpose;
                existingdatapoint.LanguageId = dataPointValues.LanguageId;
                existingdatapoint.DisclosureRequirementId = dataPointValues.DisclosureRequirementId;
                await _unitOfWork.Repository<DataPointValues>().Update(existingdatapoint);
            }
            else
            {
                datapoint = _mapper.Map<DataPointValues>(dataPointValues);
                await _unitOfWork.Repository<DataPointValues>().AddAsync(datapoint);
            }
            
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDatapoint(DatapointDeleteRequestDto deleteRequest)
        {
            var dataPoint = await _unitOfWork.Repository<DataPointValues>().Get(uom => uom.Id == deleteRequest.Id);
            if (dataPoint == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {dataPoint.Id} not found.");
            }
            dataPoint.State = deleteRequest.State;
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

        public async Task<IEnumerable<DatapointsByOrgIdResponseDto>> GetDataPointsByOrganizationId(long organizationId)
        {
            List<long> filteredDatapoints = new List<long>();
            long? HierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);

            if (HierarchyId != null)
            {
                var datapoints = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(HierarchyId); 
                var datamodelDatapoints = await _unitOfWork.DatapointValueRepo.GetModelDatapointsByOrgId(organizationId);

                filteredDatapoints = datapoints
                    .Where(dp => !datamodelDatapoints.Any(dmd => dmd == dp))
                    .ToList();
            }
            var datapointslist = await _unitOfWork.DatapointValueRepo.GetNamesForFilteredIds(filteredDatapoints);
            var list = _mapper.Map<IEnumerable<DatapointsByOrgIdResponseDto>>(datapointslist);
            return list;
        }


        public async Task<DataPointValues> UpdateAsync(DataPointValues dataPointValues)
        {
            var res = await _unitOfWork.Repository<DataPointValues>().Update(dataPointValues);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

