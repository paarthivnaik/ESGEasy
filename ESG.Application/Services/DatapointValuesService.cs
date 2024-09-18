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

        public async Task<DatapointsByOrgIdResponseDto> GetDataPointsByOrganizationId(long organizationId)
        {
            var response = new DatapointsByOrgIdResponseDto();
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
            var disclosureRequirementIds = datapointslist.Select(dp => dp.DisclosureRequirementId).Distinct().ToList();
            var disclosureRequirements = await _unitOfWork.Repository<DisclosureRequirement>() .GetAll(dr => disclosureRequirementIds.Contains(dr.Id));
            var subTopicIds = disclosureRequirements.Select(dr => dr.StandardId).Distinct().ToList();
            var subTopics = await _unitOfWork.Repository<Standard>().GetAll(st => subTopicIds.Contains(st.Id));
            var topicIds = subTopics.Select(st => st.TopicId).Distinct().ToList();
            var topics = await _unitOfWork.Repository<Topic>().GetAll(t => topicIds.Contains(t.Id));
            foreach (var topic in topics)
            {
                var topicDto = new TopicDto
                {
                    Id = topic.Id,
                    Name = topic.ShortText,
                    StandardDto = new List<StandardDto>()
                };
                var relatedSubTopics = subTopics.Where(st => st.TopicId == topic.Id).ToList();
                foreach (var subTopic in relatedSubTopics)
                {
                    var standardDto = new StandardDto
                    {
                        Id = subTopic.Id,
                        Name = subTopic.ShortText,
                        DisclosureRequirement = new List<DisclosureRequirementDto>()
                    };
                    var relatedDisclosureRequirements = disclosureRequirements.Where(dr => dr.StandardId == subTopic.Id).ToList();
                    foreach (var disclosureRequirement in relatedDisclosureRequirements)
                    {
                        var disclosureRequirementDto = new DisclosureRequirementDto
                        {
                            Id = disclosureRequirement.Id,
                            Name = disclosureRequirement.ShortText,
                            DatapointDto = new List<DatapointDto>()
                        };
                        var relatedDatapoints = datapointslist.Where(dp => dp.DisclosureRequirementId == disclosureRequirement.Id).ToList();
                        foreach (var datapoint in relatedDatapoints)
                        {
                            var datapointDto = new DatapointDto
                            {
                                Id = datapoint.Id,
                                Name = datapoint.Name,
                                IsNarrative = datapoint.IsNarrative!.Value
                            };
                            disclosureRequirementDto.DatapointDto.Add(datapointDto);
                        }
                        standardDto.DisclosureRequirement.Add(disclosureRequirementDto);
                    }
                    topicDto.StandardDto.Add(standardDto);
                }
                response.TopicDto.Add(topicDto);
            }
            return response;
        }


        public async Task<DataPointValues> UpdateAsync(DataPointValues dataPointValues)
        {
            var res = await _unitOfWork.Repository<DataPointValues>().Update(dataPointValues);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

