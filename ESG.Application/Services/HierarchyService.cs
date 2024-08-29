using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Dto.Topics;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
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
            await _unitOfWork.HierarchyRepo.AddHierarchyRecursive(request, null);
        }

        public async Task<IEnumerable<TopicsResponseDto>> GetMethod(int tableType, long? Id)
        {
            IEnumerable<TopicsResponseDto> result = Enumerable.Empty<TopicsResponseDto>(); ;

            switch (tableType)
            {
                case 1: // topic
                    if (Id != null)
                    {
                        var topics = await _unitOfWork.HierarchyRepo.GetTopics();
                        return _mapper.Map<IEnumerable<TopicsResponseDto>>(topics);
                    }
                    break;

                case 2: // standard
                    if (Id != null)
                    {
                        var standard = await _unitOfWork.HierarchyRepo.GetStandards(Id);
                        return _mapper.Map<IEnumerable<TopicsResponseDto>>(standard);
                    }
                    break;

                case 3: // disclosurerequiremnets
                    if (Id != null)
                    {
                        var topics = await _unitOfWork.HierarchyRepo.GetDisclosureRequirements(Id);
                        return _mapper.Map<IEnumerable<TopicsResponseDto>>(topics);
                    }
                    break;

                case 4: // datapoints
                    if (Id != null)
                    {
                        var topics = await _unitOfWork.HierarchyRepo.GetDatapoints(Id);
                        return _mapper.Map<IEnumerable<TopicsResponseDto>>(topics);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid tableType provided or Id not provided.");
            }
            return result;
        }

    }
}
