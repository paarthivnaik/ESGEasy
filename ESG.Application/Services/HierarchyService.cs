﻿using AutoMapper;
using AutoMapper.Internal;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static ESG.Application.Dto.Hierarchy.HierarchyResponseDto;

namespace ESG.Application.Services
{
    public class HierarchyService : IHierarchyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HierarchyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddHierarchy(HierarchyCreateRequestDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            var existinghierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(request.OrganizationId);
            var hierarchies = new List<Hierarchy>();

            if (existinghierarchyId != null && existinghierarchyId > 0) //if hierarchy alredy exists then will have records in hierarchy alswell as DatamodelValues
            {
                var existingHierarchies = await _unitOfWork.HierarchyRepo.GetHierarchies(existinghierarchyId);
                if (request.DatapointIds != null && request.DatapointIds.Any())
                {
                    var toAddOrUpdate = new List<Hierarchy>();
                    var toRemove = new List<Hierarchy>();
                    var existingDatapointIds = existingHierarchies.Select(h => h.DataPointValuesId).ToList();
                    var requestDatapointIds = request.DatapointIds.ToHashSet();
                    toRemove = existingHierarchies
                            .Where(h => !requestDatapointIds.Contains(h.DataPointValuesId))
                            .ToList();
                    foreach (var datapointId in request.DatapointIds)
                    {
                        toAddOrUpdate = request.DatapointIds
                            .Where(datapointId => !existingDatapointIds.Contains(datapointId))
                            .Select(datapointId => new Hierarchy
                            {
                                HierarchyId = existinghierarchyId,
                                DataPointValuesId = datapointId
                            }).ToList();
                    }
                    if (toRemove.Any())
                    {
                        await _unitOfWork.Repository<Hierarchy>().RemoveRangeAsync(toRemove);
                    }
                    if (toAddOrUpdate.Any())
                    {
                        await _unitOfWork.Repository<Hierarchy>().AddRange(toAddOrUpdate);
                    }
                    //now we have to modify the records in the datamodelmodelvalues with respective datapoints

                    var existingDatamodelvalues = await _unitOfWork.DataModelRepo.GetDefaultDataModelValuesByDatapointIds(existingHierarchies.Select(a => a.DataPointValuesId).ToList(), Domain.Enum.StateEnum.active, request.OrganizationId);
                    
                    if (existingDatamodelvalues.Count() > 0 )
                    {
                        var existingdps = existingDatamodelvalues
                            .Select(a => a.DataPointValuesId)
                            .Where(id => id.HasValue)
                            .Select(id => id.Value)
                            .Distinct()
                            .ToList();
                        var newdps = request.DatapointIds
                            .Except(existingdps)
                            .ToList();
                        if (newdps.Count() > 0)
                        {
                            await GenerateDefaultDataModelValues(newdps, request);
                        }
                    }
                    if (existingDatamodelvalues.Count() <= 0)
                    {
                        await GenerateDefaultDataModelValues(request.DatapointIds, request);
                    }
                }
            }
            if (existinghierarchyId <= 0) 
            {
                var hierarchyId = await _unitOfWork.HierarchyRepo.GetNextHierarchyIdAsync();
                if (request.DatapointIds != null && request.DatapointIds.Any())
                {
                    foreach (var datapointId in request.DatapointIds)
                    {
                        hierarchies.Add(new Hierarchy
                        {
                            HierarchyId = hierarchyId,
                            DataPointValuesId = datapointId
                        });
                    }
                    await _unitOfWork.Repository<Hierarchy>().AddRange(hierarchies);
                }
                var organizationHierarchy = new OrganizationHeirarchy
                {
                    HierarchyId = hierarchyId,
                    OrganizationId = request.OrganizationId,
                    CreatedBy = request.UserId,
                    CreatedDate = DateTime.UtcNow
                };
                await GenerateDefaultDataModelValues(request.DatapointIds, request);//if hierarchy created newly then we have to create defaultdatamodelvalues for all dps
                await _unitOfWork.Repository<OrganizationHeirarchy>().AddAsync(organizationHierarchy);
            }
            await _unitOfWork.SaveAsync();
        }
        private async Task GenerateDefaultDataModelValues(List<long> datapoints, HierarchyCreateRequestDto request)
        {
            var defaultDatamodelValues = new List<DefaultDataModelValue>();
            var defaultDatamodel = await _unitOfWork.DataModelRepo.GetDefaultModel();
            var factconfigId = defaultDatamodel.ModelConfigurations.Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Fact).FirstOrDefault();
            var narrativeconfigId = defaultDatamodel.ModelConfigurations.Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Narrative).FirstOrDefault();
            var factrowdimtypeId = factconfigId.RowId;
            var modeldimensiontypeIdforFactRow = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == factconfigId.RowId).FirstOrDefault();
            var modeldimensiontypeIdforFactColumn = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == factconfigId.ColumnId).FirstOrDefault();
            var modeldimensiontypeIdforNarrativeRow = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == narrativeconfigId.RowId).FirstOrDefault();
            var factrowDimensions = await _unitOfWork.DataModelRepo.GetModelDimensionValuesByTypeIdAndModelId(modeldimensiontypeIdforFactRow.Id, defaultDatamodel.Id);
            var factcoldimensions = await _unitOfWork.DataModelRepo.GetModelDimensionValuesByTypeIdAndModelId(modeldimensiontypeIdforFactColumn.Id, defaultDatamodel.Id);
            var narrativerowDimensions = await _unitOfWork.DataModelRepo.GetModelDimensionValuesByTypeIdAndModelId(modeldimensiontypeIdforNarrativeRow.Id, defaultDatamodel.Id);
            var factfiltercombinations = defaultDatamodel.ModelFilterCombinations
                .Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Fact)
                .Select(a => (long ?)a.Id)
                .ToList();
            var narrativefiltercombinations = defaultDatamodel.ModelFilterCombinations
                .Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Narrative)
                .Select(a => a.Id).ToList();

            var factcombinations = GenerateCombinations(factrowDimensions.Select(a => a.Id), factcoldimensions.Select(a => a.Id), factfiltercombinations);
            var Narrativecombinations = GenerateCombinations(factrowDimensions.Select(a => a.Id), narrativefiltercombinations);
            foreach (var dp in datapoints)
            {
                var viewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(dp);
                if (viewtype != null && viewtype == true)
                {
                    foreach (var narrative in Narrativecombinations)
                    {
                        var matchingRowDimension = narrativerowDimensions.FirstOrDefault(a => a.Id == narrative.Item1 || a.Id == narrative.Item2);
                        var defaultdatamodelvalue = new DefaultDataModelValue();
                        defaultdatamodelvalue.DataModelId = defaultDatamodel.Id;
                        defaultdatamodelvalue.DataPointValuesId = dp;
                        defaultdatamodelvalue.CreatedBy = request.UserId;
                        defaultdatamodelvalue.LastModifiedBy = request.UserId;
                        defaultdatamodelvalue.RowId = matchingRowDimension.Id;
                        defaultdatamodelvalue.ColumnId = null;
                        defaultdatamodelvalue.CombinationId = (matchingRowDimension.Id == narrative.Item1) ? narrative.Item2 : narrative.Item1;
                        defaultdatamodelvalue.State = Domain.Enum.StateEnum.active;
                        defaultdatamodelvalue.OrganizationId = request.OrganizationId;
                        defaultDatamodelValues.Add(defaultdatamodelvalue);
                    }
                }
                if (viewtype != null && viewtype == false)
                {
                    foreach (var fact in factcombinations)
                    {
                        var matchingRowDimension = factrowDimensions.FirstOrDefault(a => a.Id == fact.Item1 || a.Id == fact.Item2 || a.Id == fact.Item3);
                        var matchingColDimension = factcoldimensions.FirstOrDefault(a => a.Id == fact.Item1 || a.Id == fact.Item2 || a.Id == fact.Item3);
                        var usedIds = new HashSet<long> { matchingRowDimension.Id, matchingColDimension.Id };
                        var combId = new[] { fact.Item1, fact.Item2, fact.Item3 }
                        .FirstOrDefault(id => !usedIds.Contains(id.Value));
                        var defaultdatamodelvalue = new DefaultDataModelValue();
                        defaultdatamodelvalue.DataModelId = defaultDatamodel.Id;
                        defaultdatamodelvalue.DataPointValuesId = dp;
                        defaultdatamodelvalue.CreatedBy = request.UserId;
                        defaultdatamodelvalue.LastModifiedBy = request.UserId;
                        defaultdatamodelvalue.RowId = matchingRowDimension.Id;
                        defaultdatamodelvalue.ColumnId = matchingColDimension.Id;
                        defaultdatamodelvalue.CombinationId = combId;
                        defaultdatamodelvalue.State = Domain.Enum.StateEnum.active;
                        defaultdatamodelvalue.OrganizationId = request.OrganizationId;
                        defaultDatamodelValues.Add(defaultdatamodelvalue);
                    }
                }
                await _unitOfWork.Repository<DefaultDataModelValue>().AddRange(defaultDatamodelValues);
            }
            
        }
        public List<(long, long, long?)> GenerateCombinations(IEnumerable<long> list1, IEnumerable<long> list2, IEnumerable<long?> list3)
        {
            list1 = list1 ?? Enumerable.Empty<long>();
            list2 = list2 ?? Enumerable.Empty<long>();
            list3 = list3 ?? Enumerable.Empty<long?>();
            return list1.SelectMany(item1 => list2, (item1, item2) => (item1, item2))
                        .SelectMany(tuple => list3, (tuple, item3) => (tuple.Item1, tuple.Item2, item3))
                        .ToList();
        }
        public List<(long, long)> GenerateCombinations(IEnumerable<long> list1, IEnumerable<long> list2)
        {
            list1 = list1 ?? Enumerable.Empty<long>();
            list2 = list2 ?? Enumerable.Empty<long>();
            return list1.SelectMany(item1 => list2, (item1, item2) => (item1, item2))
                        .ToList();
        }

        public async Task<IEnumerable<HeirarchyDataResponseDto>> GetMethod(int tableType, long? Id, long? organizationId)
        {
            IEnumerable<HeirarchyDataResponseDto> result = Enumerable.Empty<HeirarchyDataResponseDto>(); ;

            switch (tableType)
            {
                case 1: // topic
                        var topics = await _unitOfWork.HierarchyRepo.GetTopics();
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(topics);
                    break;

                case 2: // standard
                    if (Id != null)
                    {
                        var standard = await _unitOfWork.HierarchyRepo.GetStandards(Id);
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(standard);
                    }
                    break;

                case 3: // disclosurerequiremnets
                    if (Id != null)
                    {
                        var disreq = await _unitOfWork.HierarchyRepo.GetDisclosureRequirements(Id);
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(disreq);
                    }
                    break;

                case 4: // datapoints
                    if (Id != null)
                    {
                        var datapoints = await _unitOfWork.HierarchyRepo.GetDatapoints(Id, organizationId);
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(datapoints);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid tableType provided or DatapointId not provided.");
            }
            return result;
        }

        public async Task<HierarchyResponseDto> GetHierarchyByOrganizationId(long organizationId)
        {
            var mainDto = new HierarchyResponseDto();
            var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);
            if (hierarchyId != 0)
            {
                var datapointIds = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(hierarchyId);
                var datapointdetails = await _unitOfWork.DatapointValueRepo.GetDatapointValueDetailsByIds(datapointIds);
                var disclosureRequirementIds = datapointdetails.Select(dp => dp.DisclosureRequirementId).Distinct().ToList();
                var disclosureRequirements = await _unitOfWork.Repository<DisclosureRequirement>()
                    .GetAll(dr => disclosureRequirementIds.Contains(dr.Id));
                var subTopicIds = disclosureRequirements.Select(dr => dr.StandardId).Distinct().ToList();
                var subTopics = await _unitOfWork.Repository<Standard>()
                    .GetAll(st => subTopicIds.Contains(st.Id));
                var topics = await _unitOfWork.Repository<Topic>()
                   .GetAll();

                var topicDtos = topics.Select(t => new TopicDto
                {
                    Id = t.Id,
                    Name = t.ShortText,
                }).ToList();

                var subTopicDtos = subTopics.Select(st => new SubTopicDto
                {
                    Id = st.Id,
                    Name = st.ShortText,
                    TopicId = st.TopicId
                }).ToList();

                var disclosureRequirementDtos = disclosureRequirements.Select(dr => new DisclosureRequirementDto
                {
                    Id = dr.Id,
                    Name = dr.ShortText,
                    SubTopicId = (long)dr.StandardId,
                }).ToList();

                var dataPointDtos = datapointdetails.Select(dp => new DataPointDto
                {
                    Id = dp.Id,
                    Name = dp.Name,
                    UOMCode = (dp.UnitOfMeasure?.Code ?? dp.Currency?.CurrencyCode) ?? "Narrative",
                    DisclosureRequirementId = dp.DisclosureRequirementId.HasValue ? (long)dp.DisclosureRequirementId : 0,
                }).ToList();

                mainDto.Topics = topicDtos;
                mainDto.SubTopics = subTopicDtos;
                mainDto.DisclosureRequirements = disclosureRequirementDtos;
                mainDto.DataPoints = dataPointDtos;
            }
            return mainDto;
        
        }
        public async Task<List<DatapointsForDataModelResponseDto>> GetDatapointsForDataModel(long organizationId)
        {
            var response = new List<DatapointsForDataModelResponseDto>();
            List<long> filteredDatapoints = new List<long>();

            long? HierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);

            if (HierarchyId != null)
            {
                var datapoints = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(HierarchyId);
                var datamodelDatapoints = await _unitOfWork.DatapointValueRepo.GetModelDatapointsByOrgId(organizationId);
                var defaultModelDatapoints = await _unitOfWork.DatapointValueRepo.GetDefaultModelDatapointsAndNotUserAssignedByOrgId(organizationId);
                var datamodelDatapointSet = new HashSet<long>(datamodelDatapoints);
                var defaultModelDatapointSet = new HashSet<long?>(defaultModelDatapoints);
                filteredDatapoints = datapoints
                    .Where(dp => !datamodelDatapointSet.Contains(dp) && defaultModelDatapointSet.Contains(dp))
                    .ToList();
            }

            var datapointslist = await _unitOfWork.DatapointValueRepo.GetNamesForFilteredIds(filteredDatapoints);
            var disclosureRequirementIds = datapointslist.Select(dp => dp.DisclosureRequirementId).Distinct().ToList();
            var disclosureRequirements = (await _unitOfWork.Repository<DisclosureRequirement>()
                .GetAll(dr => disclosureRequirementIds.Contains(dr.Id))).ToList();
            var subTopicIds = disclosureRequirements.Select(dr => dr.StandardId).Distinct().ToList();
            var subTopics = (await _unitOfWork.Repository<Standard>().GetAll(st => subTopicIds.Contains(st.Id))).ToList();
            var topicIds = subTopics.Select(st => st.TopicId).Distinct().ToList();
            var topics = (await _unitOfWork.Repository<Topic>().GetAll(t => topicIds.Contains(t.Id))).ToList();

            foreach (var topic in topics)
            {
                var topicDto = new DatapointsForDataModelResponseDto
                {
                    Id = topic.Id,
                    Name = topic.ShortText,
                    Children = new List<HierarchyStandard>() 
                };
                var relatedSubTopics = subTopics.Where(st => st.TopicId == topic.Id).ToList();
                foreach (var subTopic in relatedSubTopics)
                {
                    var standardDto = new HierarchyStandard
                    {
                        Id = subTopic.Id,
                        Name = subTopic.ShortText,
                        Children = new List<HierarchyDisclosureRequirement>() 
                    };

                    var relatedDisclosureRequirements = disclosureRequirements.Where(dr => dr.StandardId == subTopic.Id).ToList();
                    foreach (var disclosureRequirement in relatedDisclosureRequirements)
                    {
                        var disclosureRequirementDto = new HierarchyDisclosureRequirement
                        {
                            Id = disclosureRequirement.Id,
                            Name = disclosureRequirement.ShortText,
                            children = new List<HierarchyDatapoint>()
                        };

                        var relatedDatapoints = datapointslist.Where(dp => dp.DisclosureRequirementId == disclosureRequirement.Id).ToList();
                        foreach (var datapoint in relatedDatapoints)
                        {
                            if (datapoint != null)
                            {
                                var datapointDto = new HierarchyDatapoint
                                {
                                    Id = datapoint.Id,
                                    Name = datapoint.Name,
                                    IsNarrative = datapoint.IsNarrative
                                };

                                disclosureRequirementDto.children.Add(datapointDto); 
                            }
                        }
                        standardDto.Children.Add(disclosureRequirementDto);
                    }
                    topicDto.Children.Add(standardDto);
                }
                response.Add(topicDto);
            }
            return response;
        }

        public async Task<List<GetDatapointsAssignedToUserResponseDto>> GetDatapointsAssignedToUser(long organizationId, long userId)
        {
            var mainDto = new List<GetDatapointsAssignedToUserResponseDto>();
            var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);
            if (hierarchyId != 0)
            {
                var defaultDataModelValues = await _unitOfWork.DataModelRepo.GetDefaultDataModelValuesyOrgaidAndResponsibleUser(organizationId, userId);
                var dataModelValues = await _unitOfWork.DataModelRepo.GetDataModelValuesyOrgaidAndResponsibleUser(organizationId, userId);
                var defaultDataModelIds = defaultDataModelValues.Where(id => id.HasValue).Select(id => id.Value).ToList();
                var datapointIds = defaultDataModelIds.Concat(dataModelValues).ToList();
                var datapointdetails = await _unitOfWork.DatapointValueRepo.GetDatapointValueDetailsByIds(datapointIds);
                foreach( var datapoint in datapointdetails)
                {
                    var res = new GetDatapointsAssignedToUserResponseDto();
                    res.Id = datapoint.Id;
                    res.Name = datapoint.Name;
                    res.UOMCode = (datapoint.UnitOfMeasure?.Code ?? datapoint.Currency?.CurrencyCode) ?? "Narrative";
                    mainDto.Add(res);
                }
            }
            return mainDto;
        }
    }
}
