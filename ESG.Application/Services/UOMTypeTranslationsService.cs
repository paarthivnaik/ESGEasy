using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Dto.UOMTypeTranslations;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class UOMTypeTranslationsService : IUOMTypeTranslationsService
    {
        private readonly IUnitOfWork _unitOfMeasure;
        private readonly IMapper _mapper;
        public UOMTypeTranslationsService(IUnitOfWork unitOfMeasure, IMapper mapper)
        {
            _unitOfMeasure = unitOfMeasure;
            _mapper = mapper;
        }
        public async Task Add(UOMTypeTranslationsCreateRequestDto requestDto)
        {
            if (requestDto != null)
            {
                var existingTranslation = await _unitOfMeasure.Repository<UnitOfMeasureTypeTranslation>()
                    .Get(a => a.UnitOfMeasureTypeId == requestDto.UnitOfMeasureTypeId && a.LanguageId == requestDto.LanguageId);
                if (existingTranslation != null)
                {
                    existingTranslation.LanguageId = requestDto.LanguageId;
                    existingTranslation.ShortText = requestDto.ShortText;
                    existingTranslation.LongText = requestDto.LongText;
                    existingTranslation.State = requestDto.State;
                    existingTranslation.LastModifiedBy = requestDto.UserId;
                    existingTranslation.LastModifiedDate = DateTime.UtcNow;
                    existingTranslation.Name = requestDto.Name;
                    await _unitOfMeasure.Repository<UnitOfMeasureTypeTranslation>().UpdateAsync(existingTranslation.Id, existingTranslation);
                }
                if (existingTranslation == null)
                {
                    var uomTranslationdata = _mapper.Map<UnitOfMeasureTypeTranslation>(requestDto);
                    uomTranslationdata.State = requestDto.State;
                    uomTranslationdata.LastModifiedBy = requestDto.UserId;
                    uomTranslationdata.LastModifiedDate = DateTime.UtcNow;
                    uomTranslationdata.CreatedDate = DateTime.UtcNow;
                    await _unitOfMeasure.Repository<UnitOfMeasureTypeTranslation>().AddAsync(uomTranslationdata);
                }
            }
            await _unitOfMeasure.SaveAsync();
        }

        public async Task Update(UOMTypeTranslationsUpdateRequestDto uomTypeTranslationsUpdateRequestDto)
        {
            var translationsData = await _unitOfMeasure.Repository<UnitOfMeasureTypeTranslation>()
                .Get(uom => uom.UnitOfMeasureTypeId == uomTypeTranslationsUpdateRequestDto.UnitOfMeasureTypeId && uom.LanguageId == uomTypeTranslationsUpdateRequestDto.LanguageId);
            if (translationsData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {translationsData.Id} not found.");
            }
            translationsData.ShortText = uomTypeTranslationsUpdateRequestDto.ShortText;
            translationsData.LongText = uomTypeTranslationsUpdateRequestDto.LongText;
            translationsData.State = uomTypeTranslationsUpdateRequestDto.State;
            translationsData.Name = uomTypeTranslationsUpdateRequestDto.Name;
            translationsData.CreatedBy = uomTypeTranslationsUpdateRequestDto.UserId;

            await _unitOfMeasure.Repository<UnitOfMeasureTypeTranslation>().Update(translationsData);
            await _unitOfMeasure.SaveAsync();
        }
    }
}
