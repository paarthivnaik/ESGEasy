using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var hierarchyId = await _unitOfWork.HierarchyRepo.GetNextHierarchyIdAsync();
            var hierarchies = new List<Hierarchy>();
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
                var organizationHierarchy = new OrganizationHeirarchies
                {
                    HierarchyId = hierarchyId,
                    OrganizationId = request.OrganizationId,
                    CreatedBy = request.UserId,
                    CreatedDate = DateTime.UtcNow,
                };
                await _unitOfWork.Repository<OrganizationHeirarchies>().AddAsync(organizationHierarchy);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<IEnumerable<HeirarchyDataResponseDto>> GetMethod(int tableType, long? Id)
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
                        var datapoints = await _unitOfWork.HierarchyRepo.GetDatapoints(Id);
                        return _mapper.Map<IEnumerable<HeirarchyDataResponseDto>>(datapoints);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid tableType provided or Id not provided.");
            }
            return result;
        }

        public async Task<HierarchyResponseDto> GetHierarchyData(long organizationId)
        {
            var mainDto = new HierarchyResponseDto();
            var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);

            if (hierarchyId != 0)
            {
                var datapointIds = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(hierarchyId);

                var datapointValues = await _unitOfWork.Repository<DataPointValues>()
                    .GetAll(dp => datapointIds.Contains(dp.Id));

                var disclosureRequirementIds = datapointValues.Select(dp => dp.DisclosureRequirementId).Distinct().ToList();

                var disclosureRequirements = await _unitOfWork.Repository<DisclosureRequirement>()
                    .GetAll(dr => disclosureRequirementIds.Contains(dr.Id));

                var subTopicIds = disclosureRequirements.Select(dr => dr.StandardId).Distinct().ToList();

                var subTopics = await _unitOfWork.Repository<Standard>()
                    .GetAll(st => subTopicIds.Contains(st.Id)); 

                var topicIds = subTopics.Select(st => st.TopicId).Distinct().ToList();

                var topics = await _unitOfWork.Repository<Topic>()
                    .GetAll(t => topicIds.Contains(t.Id));

                var topicDtos = topics.Select(t => new TopicDto
                {
                    Id = t.Id
                }).ToList();

                var subTopicDtos = subTopics.Select(st => new SubTopicDto
                {
                    Id = st.Id,
                    TopicId = st.TopicId
                }).ToList();

                var disclosureRequirementDtos = disclosureRequirements.Select(dr => new DisclosureRequirementDto
                {
                    Id = dr.Id,
                    SubTopicId = (long)dr.StandardId,
                }).ToList();

                var dataPointDtos = datapointValues.Select(dp => new DataPointDto
                {
                    Id = dp.Id,
                    DisclosureRequirementId = (long)dp.DisclosureRequirementId,
                }).ToList();

                mainDto.Topics = topicDtos;
                mainDto.SubTopics = subTopicDtos;
                mainDto.DisclosureRequirements = disclosureRequirementDtos;
                mainDto.DataPoints = dataPointDtos;
            }
            return mainDto;
        
        }


        //public async Task<HierarchyResponseDto> GetHierarchydata(long organizationId)
        //{
        //    var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);
        //    var response = new HierarchyResponseDto();
        //    if (hierarchyId != null && hierarchyId > 0)
        //    {
        //        var hierarchy = await _unitOfWork.HierarchyRepo.GetHierarchyById(hierarchyId);
        //        response.HierarchyId = hierarchyId!.Value;
        //        response.DatapointId = new List<long>();
        //        foreach (var item in hierarchy)
        //        {
        //            response.DatapointId.Add(item.DataPointValuesId);
        //        }
        //    }
        //    if (hierarchyId == 0 || hierarchyId == null)
        //    {
        //        var hierarchy = await _unitOfWork.HierarchyRepo.GetHierarchyById(1);
        //        response.HierarchyId = 1;
        //        response.DatapointId = new List<long>();
        //        foreach (var item in hierarchy)
        //        {
        //            response.DatapointId.Add(item.DataPointValuesId);
        //        }
        //    }
        //    return response; 
        //}


    }
}
