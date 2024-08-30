using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class UnitOfMeasureTypeService : IUnitOfMeasureTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public UnitOfMeasureTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(UnitOfMeasureTypeCreateRequestDto unitOfMeasureType)
        {
            if (unitOfMeasureType.UnitOfMeasureTypeId > 0)
            {
                var uomTypeTranslationdata = _mapper.Map<UnitOfMeasureTypeTranslations>(unitOfMeasureType);
                await _unitOfWork.Repository<UnitOfMeasureTypeTranslations>().AddAsync(uomTypeTranslationdata);
            }
            else
            {
                var uomType = _mapper.Map<UnitOfMeasureType>(unitOfMeasureType);
                var uomTypeTranslationdata = _mapper.Map<UnitOfMeasureTypeTranslations>(unitOfMeasureType);
                uomTypeTranslationdata.UnitOfMeasureTypeId = uomType.Id;
                uomType.UnitOfMeasureTypeTranslations = new List<UnitOfMeasureTypeTranslations> { uomTypeTranslationdata };
                await _unitOfWork.Repository<UnitOfMeasureType>().AddAsync(uomType);
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAsync(UnitOfMeasureType unitOfMeasureType)
        {
            await _unitOfWork.Repository<UnitOfMeasureType>().AddAsync(unitOfMeasureType);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUOMType(UnitOfMeasureTypeDeleteRequestDto deleteRequest)
        {
            var uomType = await _unitOfWork.Repository<UnitOfMeasureType>().Get(uom => uom.Id == deleteRequest.Id);
            if (uomType == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {uomType.Id} not found.");
            }
            uomType.State = StateEnum.deleted;
            await _unitOfWork.Repository<UnitOfMeasureType>().Update(uomType);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAll()
        {
            var list = await _unitOfWork.Repository<UnitOfMeasureType>().GetAll();
            var data = _mapper.Map<IEnumerable<UnitOfMeasureTypeResponseDto>>(list);
            return data;
        }

        public async Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAllTranslations(long Id)
        {
            var list = await _unitOfWork.Repository<UnitOfMeasureTypeTranslations>().GetAll(a => a.UnitOfMeasureTypeId == Id);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureTypeResponseDto>>(list);
            return data;
        }

        public async Task UpdateAsync(UnitOfMeasureTypeUpdateRequestDto unitOfMeasureType)
        {
            var existingData = await _unitOfWork.Repository<UnitOfMeasureType>()
                .Get(u => u.Id == unitOfMeasureType.Id && u.LanguageId == unitOfMeasureType.LanguageId);
            var translationsData = await _unitOfWork.Repository<UnitOfMeasureTypeTranslations>()
                .Get(uom => uom.UnitOfMeasureTypeId == unitOfMeasureType.Id && uom.LanguageId == unitOfMeasureType.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {unitOfMeasureType.Id} not found.");
            }
            existingData.ShortText = unitOfMeasureType.ShortText;
            existingData.LongText = unitOfMeasureType.LongText;
            existingData.State = unitOfMeasureType.State;
            existingData.Name = unitOfMeasureType.Name;
            existingData.OrganizationId = unitOfMeasureType.OrganizationId;

            translationsData.ShortText = unitOfMeasureType.ShortText;
            translationsData.LongText = unitOfMeasureType.LongText;
            translationsData.State = unitOfMeasureType.State;
            translationsData.Name = unitOfMeasureType.Name;

            await _unitOfWork.Repository<UnitOfMeasureType>().Update(existingData);
            await _unitOfWork.Repository<UnitOfMeasureTypeTranslations>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }
    }
}
