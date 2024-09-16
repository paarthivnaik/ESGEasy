using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities.DomainEntities;
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

        public async Task Add(UOMTranslationsCreateRequestDto uOMTranslationsCreateRequestDto)
        {
            if (uOMTranslationsCreateRequestDto != null)
            {
                var uomTranslationdata = _mapper.Map<UnitOfMeasureTranslations>(uOMTranslationsCreateRequestDto);
                await _unitOfMeasure.Repository<UnitOfMeasureTranslations>().AddAsync(uomTranslationdata);
                await _unitOfMeasure.SaveAsync();
            }
        }
        public async Task Update(UOMTranslationsUpdateRequestDto uomTranslationrequest)
        {
            var translationsData = await _unitOfMeasure.Repository<UnitOfMeasureTranslations>()
                .Get(uom => uom.UnitOfMeasureId == uomTranslationrequest.UnitOfMeasureId && uom.LanguageId == uomTranslationrequest.LanguageId);
            if (translationsData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {translationsData.Id} not found.");
            }
            translationsData.ShortText = uomTranslationrequest.ShortText;
            translationsData.LongText = uomTranslationrequest.LongText;
            translationsData.State = uomTranslationrequest.State;
            translationsData.Name = uomTranslationrequest.Name;
            translationsData.CreatedBy = uomTranslationrequest.UserId;

            await _unitOfMeasure.Repository<UnitOfMeasureTranslations>().Update(translationsData);
            await _unitOfMeasure.SaveAsync();
        }
    }
}
