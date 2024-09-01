using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Dimensions;
using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DimentionTypeService : IDimentionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DimentionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(DimensionTypeCreateRequestDto dimentionType)
        {
            if (dimentionType.DimensionTypeId > 0)
            {
                var dimensionsTranslateddata = _mapper.Map<DimensionTypeTranslations>(dimentionType);
                await _unitOfWork.Repository<DimensionTypeTranslations>().AddAsync(dimensionsTranslateddata);
            }
            else
            {
                var dimensonsdata = _mapper.Map<DimensionType>(dimentionType);
                var dimensonsTranslationdata = _mapper.Map<DimensionTypeTranslations>(dimentionType);
                dimensonsTranslationdata.DimensionTypeId = dimensonsdata.Id;
                //dimensonsdata.DimensionTypeTranslations = new List<DimensionTypeTranslations> { dimensonsTranslationdata };
                await _unitOfWork.Repository<DimensionType>().AddAsync(dimensonsdata);
            }
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(DimensionTypeUpdateRequestDto dimentionType)
        {
            var existingData = await _unitOfWork.Repository<DimensionType>()
                .Get(u => u.Id == dimentionType.Id && u.LanguageId == dimentionType.LanguageId);
            var translationsData = await _unitOfWork.Repository<DimensionTypeTranslations>()
                .Get(uom => uom.DimensionTypeId == dimentionType.Id && uom.LanguageId == dimentionType.LanguageId);
            if (existingData == null || translationsData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {dimentionType.Id} not found.");
            }
            existingData.ShortText = dimentionType.ShortText;
            existingData.LongText = dimentionType.LongText;
            existingData.Code = dimentionType.Code;
            existingData.State = dimentionType.State;
            
            translationsData.ShortText = dimentionType.ShortText;
            translationsData.LongText = dimentionType.LongText;
            translationsData.State = dimentionType.State;
            translationsData.Name = dimentionType.Name;
            await _unitOfWork.Repository<DimensionType>().Update(existingData);
            await _unitOfWork.Repository<DimensionTypeTranslations>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(DimensionTypeDeleteRequestDto request)
        {
            var dimension = await _unitOfWork.Repository<DimensionType>().Get(uom => uom.Id == request.Id);
            if (dimension == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {dimension.Id} not found.");
            }
            dimension.State = StateEnum.deleted;
            await _unitOfWork.Repository<DimensionType>().Update(dimension);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionTypeResponseDto>> GetAll()
        {
            var list = await _unitOfWork.Repository<DimensionType>().GetAll();
            return _mapper.Map<IEnumerable<DimensionTypeResponseDto>>(list);
        }

        public async Task<DimensionType> GetById(long Id)
        {
            return await _unitOfWork.Repository<DimensionType>().Get(Id);
        }
    }
}
