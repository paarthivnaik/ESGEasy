using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class UOMTranslationService : IUOMTranslationsService
    {
        private readonly IUnitOfWork _unitOfMeasure;
        private readonly IMapper _mapper;
        public UOMTranslationService(IUnitOfWork unitOfMeasure, IMapper mapper)
        {
            _unitOfMeasure = unitOfMeasure;
            _mapper = mapper;
        }

        public async Task Add(UOMTranslationsCreateRequestDto requestDto)
        {
            if (requestDto != null)
            {
                var existingTranslation = await _unitOfMeasure.Repository<UnitOfMeasureTranslation>()
                    .Get(a => a.UnitOfMeasureId == requestDto.UnitOfMeasureId && a.LanguageId == requestDto.LanguageId);
                if (existingTranslation != null)
                {
                    existingTranslation.LanguageId = requestDto.LanguageId;
                    existingTranslation.ShortText = requestDto.ShortText;
                    existingTranslation.LongText = requestDto.LongText;
                    existingTranslation.State = requestDto.State;
                    existingTranslation.LastModifiedBy = requestDto.UserId;
                    existingTranslation.LastModifiedDate = DateTime.UtcNow;
                    await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().UpdateAsync(existingTranslation.Id, existingTranslation);
                }
                if (existingTranslation == null)
                {
                    var uomTranslationdata = _mapper.Map<UnitOfMeasureTranslation>(requestDto);
                    uomTranslationdata.State = requestDto.State;
                    uomTranslationdata.LastModifiedBy = requestDto.UserId;
                    uomTranslationdata.LastModifiedDate = DateTime.UtcNow;
                    uomTranslationdata.CreatedDate = DateTime.UtcNow;
                    await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().AddAsync(uomTranslationdata);
                }
                
                await _unitOfMeasure.SaveAsync();
            }
        }
        public async Task Update(UOMTranslationsUpdateRequestDto uomTranslationrequest)
        {
            var translationsData = await _unitOfMeasure.Repository<UnitOfMeasureTranslation>()
                .Get(uom => uom.UnitOfMeasureId == uomTranslationrequest.UnitOfMeasureId && uom.LanguageId == uomTranslationrequest.LanguageId);
            if (translationsData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {translationsData.Id} not found.");
            }
            translationsData.ShortText = uomTranslationrequest.ShortText;
            translationsData.LongText = uomTranslationrequest.LongText;
            translationsData.State = uomTranslationrequest.State;
            translationsData.CreatedBy = uomTranslationrequest.UserId;

            await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().Update(translationsData);
            await _unitOfMeasure.SaveAsync();
        }
    }
}
