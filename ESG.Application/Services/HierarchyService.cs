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

        public async Task<IEnumerable<HierarchyResponseDto>> GetHierarchydata(long organiizationId)
        {
            var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organiizationId);
            var heirarchy = await _unitOfWork.HierarchyRepo.GetHierarchydata(hierarchyId);
            return _mapper.Map<IEnumerable<HierarchyResponseDto>>(heirarchy);
        }
    }
}
