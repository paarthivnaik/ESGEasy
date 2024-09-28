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
        public async Task Add(UOMTypeTranslationsCreateRequestDto uomTypeTranslationsCreateRequestDto)
        {
            if (uomTypeTranslationsCreateRequestDto != null)
            {
                var uomTranslationdata = _mapper.Map<UnitOfMeasureTypeTranslation>(uomTypeTranslationsCreateRequestDto);
                await _unitOfMeasure.Repository<UnitOfMeasureTypeTranslation>().AddAsync(uomTranslationdata);
                await _unitOfMeasure.SaveAsync();
            }
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
