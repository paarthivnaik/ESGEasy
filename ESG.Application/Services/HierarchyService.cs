using AutoMapper;
using AutoMapper.Internal;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
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
                if (request.DatapointIds != null)
                {
                    var toAddOrUpdate = new List<Hierarchy>();
                    var toRemove = new List<Hierarchy>();
                    var existingHierarchyDatapointIds = existingHierarchies.Select(h => h.DataPointValuesId).ToList();
                    var requestHierarchyDatapointIds = request.DatapointIds.ToHashSet();
                    toRemove = existingHierarchies
                            .Where(h => !requestHierarchyDatapointIds.Contains(h.DataPointValuesId))
                            .ToList();
                    foreach (var datapointId in request.DatapointIds)
                    {
                        toAddOrUpdate = request.DatapointIds
                            .Where(datapointId => !existingHierarchyDatapointIds.Contains(datapointId))
                            .Select(datapointId => new Hierarchy
                            {
                                HierarchyId = existinghierarchyId,
                                DataPointValuesId = datapointId
                            }).ToList();
                    }
                    if (toRemove.Any())
                    {
                        //now we have to modify the records in the datamodelmodelvalues with respective datapoints
                        await _unitOfWork.Repository<Hierarchy>().RemoveRangeAsync(toRemove);
                        var list = await _unitOfWork.DataModelRepo.GetDataModelValuesByDatapointIDsOrgId
                                (toRemove.Select(a => a.DataPointValuesId).ToList(), request.OrganizationId);
                        var modeldatapoints = await _unitOfWork.DataModelRepo.GetModelDatapointsByOrganizationId
                            (toRemove.Select(a => a.DataPointValuesId).ToList(), request.OrganizationId);
                        if (list.Any())
                            await _unitOfWork.Repository<DataModelValue>().RemoveRangeAsync(list);
                        await _unitOfWork.Repository<ModelDatapoint>().RemoveRangeAsync(modeldatapoints);
                    }
                    if (toAddOrUpdate.Any())
                    {
                        await _unitOfWork.Repository<Hierarchy>().AddRangeAsync(toAddOrUpdate);
                        var list = await _unitOfWork.DataModelRepo.GenerateDataModelValues
                            (toAddOrUpdate.Select(a => a.DataPointValuesId).ToList(), request.OrganizationId, request.UserId);
                        await _unitOfWork.Repository<DataModelValue>().AddRangeAsync(list);
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
                    await _unitOfWork.Repository<Hierarchy>().AddRangeAsync(hierarchies);
                }
                var organizationHierarchy = new OrganizationHeirarchy
                {
                    HierarchyId = hierarchyId,
                    OrganizationId = request.OrganizationId,
                    CreatedBy = request.UserId,
                    CreatedDate = DateTime.UtcNow
                };
                if (request.DatapointIds != null)
                {
                    var reminingDatapoints = await _unitOfWork.HierarchyRepo.GetRemainingDatapointsByOrganizationId(request.OrganizationId);
                    var datamodelvalues = await _unitOfWork.DataModelRepo.GenerateDataModelValues(reminingDatapoints.ToList(), request.OrganizationId, request.UserId);
                    await _unitOfWork.Repository<DataModelValue>().AddRangeAsync(datamodelvalues);
                    //if hierarchy created newly then we have to create defaultdatamodelvalues for all dps
                }
                await _unitOfWork.Repository<OrganizationHeirarchy>().AddAsync(organizationHierarchy);
            }
            await _unitOfWork.SaveAsync();
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

        public async Task<IEnumerable<HeirarchyDataResponseDto>> GetMethod(int tableType, long? Id, long? organizationId, long? languageId)
        {
            IEnumerable<HeirarchyDataResponseDto> result = Enumerable.Empty<HeirarchyDataResponseDto>(); ;
            if (languageId == null)
                languageId = 1;
            switch (tableType)
            {
                case 1: // topic
                    var topics = await _unitOfWork.HierarchyRepo.GetTopicTranslationsByLangId(languageId, organizationId,null);                    
                    return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(topics);
                    break;

                case 2: // standard
                    if (Id != null)
                    {
                        var standard = await _unitOfWork.HierarchyRepo.GetStandardTranslationsByLangId(languageId, organizationId,tableType,Id);                        
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(standard);
                    }
                    break;

                case 3: // disclosurerequiremnets
                    if (Id != null)
                    {                        
                        var disreq = await _unitOfWork.HierarchyRepo.GetDisclosureRequirementTranslations(languageId, organizationId, tableType, Id);                          
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(disreq).OrderBy(A=>A.Id);
                    }
                    break;

                case 4: // datapoints
                    if (Id != null)
                    {
                        var datapoints = await _unitOfWork.HierarchyRepo.GetDatapointTranslations(tableType, Id,organizationId,languageId);                        
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(datapoints).OrderBy(dp=>dp.Id);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid tableType provided or DatapointId not provided.");
            }
            return result;
        }

        public async Task<HierarchyResponseDto> GetHierarchyByOrganizationId(long organizationId, long? languageId)
        {
            var mainDto = new HierarchyResponseDto();
            var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);
            if (languageId == null)
                languageId = 1;
            if (hierarchyId != 0)
            {
                var datapointIds = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(hierarchyId);
                var datapointdetails = await _unitOfWork.DatapointValueRepo.GetDatapointValueDetailsByIds(datapointIds.Select(id => (long?)id),languageId);
                                
                var disclosureRequirementIds = datapointdetails.Select(dp => dp.DisclosureRequirementId).Distinct().ToList();
                var disclosureRequirements = await _unitOfWork.DisclosureRequirementRepo.GetAllDisclosureRequirements(dr => disclosureRequirementIds.Contains(dr.Id));
                
                var subTopicIds = disclosureRequirements.Select(dr => dr.StandardId).Distinct().ToList();                
                var subTopics = await _unitOfWork.StandardRepo.GetAllStandards(st => subTopicIds.Contains(st.Id));
                
                var topics = await _unitOfWork.TopicRepo.GetAllTopics();                

                var topicDtos = topics.Select(t => new TopicDto
                {
                    Id = t.Id,                    
                    ShortText = t.TopicTranslations.Where(tt=>tt.LanguageId == languageId).Select(tt => tt.ShortText).FirstOrDefault(),
                }).ToList();

                var subTopicDtos = subTopics.Select(st => new SubTopicDto
                {
                    Id = st.Id,
                    //ShortText = st.ShortText,
                    ShortText = st.StandardTranslations.Where(stt=>stt.LanguageId == languageId).Select(sst=>sst.ShortText).FirstOrDefault(),
                    TopicId = st.TopicId
                }).ToList();

                var disclosureRequirementDtos = disclosureRequirements.Select(dr => new DisclosureRequirementDto
                {
                    Id = dr.Id,
                    //ShortText = dr.ShortText,
                    ShortText = dr.DisclosureRequirementTranslations.Where(dtt=>dtt.LanguageId == languageId).Select(dt=>dt.ShortText).FirstOrDefault(),
                    SubTopicId = (long)dr.StandardId,
                }).ToList();

                var dataPointDtos = datapointdetails.Select(dp => new DataPointDto
                {
                    Id = dp.Id,                    
                    ShortText = dp.DatapointValueTranslations.Where(dvt=>dvt.LanguageId == languageId).Select(dvt => dvt.ShortText)
                    .FirstOrDefault(),
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
        public async Task<List<DatapointsForDataModelResponseDto>> GetDatapointsForDataModel(long organizationId, long? modelId, long? languageId)
       {
            var response = new List<DatapointsForDataModelResponseDto>();
            List<long> filteredDatapoints = new List<long>();
            List<long> existingModelDatapoints = new List<long>();
            if (languageId == null)
                languageId = 1;
            long HierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);
            if (HierarchyId <= 0 || HierarchyId == null)
                return response;
            if (HierarchyId != null)
            {
                var datapoints = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(HierarchyId);
                var datamodelDatapoints = await _unitOfWork.DatapointValueRepo.GetModelDatapointsByOrgId(organizationId);
                var defaultModelDatapoints = await _unitOfWork.DatapointValueRepo.GetDataModelValuesDatapointsAndNotUserAssignedByOrgId(organizationId);
                var filteredDps = datapoints
                    .Where(dp => !datamodelDatapoints.Any(d => d == dp))
                    .ToList();
                filteredDatapoints = filteredDps
                    .Where(dp => !defaultModelDatapoints.Any(a => a == dp))
                    .ToList();
                if (modelId != null && modelId != 0)
                {
                    var ModelDatapoints = await _unitOfWork.DataModelRepo.GetDatapointsLinkedToDataModel(modelId, organizationId);
                    existingModelDatapoints = ModelDatapoints.Select(a => a.DatapointValuesId).ToList();
                    filteredDatapoints.AddRange(existingModelDatapoints);
                }
            }

            var datapointslist = await _unitOfWork.DatapointValueRepo.GetNamesForFilteredIds(filteredDatapoints,languageId);
            var disclosureRequirementIds = datapointslist.Select(dp => dp.DisclosureRequirementId).Distinct().ToList();
            
            var disclosureRequirements = await _unitOfWork.DisclosureRequirementRepo.GetAllDisclosureRequirements(dr => disclosureRequirementIds.Contains(dr.Id));
            
            var subTopicIds = disclosureRequirements.Select(dr => dr.StandardId).Distinct().ToList();
                        
            var subTopics = await _unitOfWork.StandardRepo.GetAllStandards(st => subTopicIds.Contains(st.Id));            
            var topicIds = subTopics.Select(st => st.TopicId).Distinct().ToList();
            
            var topics = await _unitOfWork.TopicRepo.GetTopicTranslations(t=>topicIds.Contains(t.Id));            
            foreach (var topic in topics)
            {
                var topicDto = new DatapointsForDataModelResponseDto
                {
                    Id = topic.Id,                    
                    ShortText = topic.TopicTranslations
                    .Where(tt => tt.LanguageId == languageId)
                    .Select(tt => tt.ShortText)
                    .FirstOrDefault(),
                    Children = new List<HierarchyStandard>() 
                };
                var relatedSubTopics = subTopics.Where(st => st.TopicId == topic.Id).ToList();
                foreach (var subTopic in relatedSubTopics)
                {
                    var standardDto = new HierarchyStandard
                    {
                        Id = subTopic.Id,                        
                        ShortText = subTopic.StandardTranslations
                        .Where(st => st.LanguageId == languageId)
                        .Select(st => st.ShortText)
                        .FirstOrDefault(),
                        Children = new List<HierarchyDisclosureRequirement>() 
                    };

                    var relatedDisclosureRequirements = disclosureRequirements.Where(dr => dr.StandardId == subTopic.Id).ToList();
                    foreach (var disclosureRequirement in relatedDisclosureRequirements)
                    {
                        var disclosureRequirementDto = new HierarchyDisclosureRequirement
                        {
                            Id = disclosureRequirement.Id,                            
                            ShortText = disclosureRequirement.DisclosureRequirementTranslations
                            .Where(dt=>dt.LanguageId == languageId)
                            .Select(dt=>dt.ShortText)
                            .FirstOrDefault(),
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
                                    ShortText = datapoint.ShortText,
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
                var datapointIds = defaultDataModelIds.Select(id => (long?)id)
                                      .Concat(dataModelValues)
                                      .ToList();
                var datapointdetails = await _unitOfWork.DatapointValueRepo.GetDatapointValueDetailsByIds(datapointIds,null);
                foreach( var datapoint in datapointdetails)
                {
                    var res = new GetDatapointsAssignedToUserResponseDto();
                    res.Id = datapoint.Id;
                    res.ShortText = datapoint.ShortText;
                    res.UOMCode = (datapoint.UnitOfMeasure?.Code ?? datapoint.Currency?.CurrencyCode) ?? "Narrative";
                    mainDto.Add(res);
                }
            }
            return mainDto;
        }

        public async Task<List<long?>> CheckDataModelValueOfDatapoint(CheckDataModelValueOfDatapointRegDto requestdto)
        {
            
            var havingValue = await _unitOfWork.DataModelRepo.IsDataPointHavinganyValue(requestdto);
            return havingValue;
        }
    }
}
