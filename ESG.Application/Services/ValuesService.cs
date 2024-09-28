using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Get;
using ESG.Application.Exception;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ValuesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTranslationsResponseDto>> GetMethod(int tableType, long typeId, long? valueId)
        {
            IEnumerable<GetTranslationsResponseDto> result;

            switch (tableType)
            {
                case 1: // UOM
                    result = await GetUOMTranslations(typeId, valueId);
                    break;

                case 2: // DataPoint
                    result = await GetDataPointTranslations(typeId, valueId);
                    break;

                case 3: // Dimension
                    result = await GetDimensionTranslation(typeId, valueId);
                    break;

                default:
                    throw new ArgumentException("Invalid tableType provided.");
            }
            return result;
        }
        private async Task<IEnumerable<GetTranslationsResponseDto>> GetUOMTranslations(long typeId, long? valueId)
        {
            if (valueId.HasValue)
            {
                var uomTranslations = await _unitOfWork.ValuesRepo.GetUOMTranslations(valueId);
                return _mapper.Map<IEnumerable<GetTranslationsResponseDto>>(uomTranslations);
            }
            else
            {
                var uomTypeTranslations = await _unitOfWork.ValuesRepo.GetUOMTypeTranslations(typeId);
                return _mapper.Map<IEnumerable<GetTranslationsResponseDto>>(uomTypeTranslations);
            }
        }

        private async Task<IEnumerable<GetTranslationsResponseDto>> GetDataPointTranslations(long typeId, long? valueId)
        {
            if (valueId.HasValue)
            {
                var dataPointTranslation = await _unitOfWork.ValuesRepo.GetDatapointTranslations(typeId, valueId);
                return _mapper.Map<IEnumerable<GetTranslationsResponseDto>>(dataPointTranslation);
            }
            else
            {
                var dataPointTypeTranslation = await _unitOfWork.ValuesRepo.GetDatapointTypeTranslations(typeId);
                return _mapper.Map<IEnumerable<GetTranslationsResponseDto>>(dataPointTypeTranslation);
            }
        }

        private async Task<IEnumerable<GetTranslationsResponseDto>> GetDimensionTranslation(long typeId, long? valueId)
        {
            if (valueId.HasValue)
            {
                var dimensionTranslation = await _unitOfWork.ValuesRepo.GetDimensionTranslations(typeId, valueId);
                return _mapper.Map<IEnumerable<GetTranslationsResponseDto>>(dimensionTranslation);
            }
            else
            {
                var dimensionTypeData = await _unitOfWork.ValuesRepo.GetDimensionTypeTranslation(typeId);
                return _mapper.Map<IEnumerable<GetTranslationsResponseDto>>(dimensionTypeData);
            }
        }
    }
}
