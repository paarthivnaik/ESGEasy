using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ESG.Application.Services
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly IUnitOfWork _unitOfMeasure;
        private readonly IMapper _mapper;
        public UnitOfMeasureService(IUnitOfWork unitOfMeasure, IMapper mapper)
        {
            _unitOfMeasure = unitOfMeasure;
            _mapper = mapper;
        }
        public async Task Add(UnitOfMeasureCreateRequestDto unitOfMeasure)
        {
            if (unitOfMeasure.UnitOfMeasureId > 0)
            {
                var uomTranslationdataOnly = _mapper.Map<UnitOfMeasureTranslations>(unitOfMeasure);
                await _unitOfMeasure.Repository<UnitOfMeasureTranslations>().AddAsync(uomTranslationdataOnly);
            }
            else
            {
                var uomdata = _mapper.Map<UnitOfMeasure>(unitOfMeasure);
                var uomTranslationdata = _mapper.Map<UnitOfMeasureTranslations>(unitOfMeasure);
                uomTranslationdata.UnitOfMeasureId = uomdata.Id;
                uomdata.UnitOfMeasureTranslations = new List<UnitOfMeasureTranslations> { uomTranslationdata };
                await _unitOfMeasure.Repository<UnitOfMeasure>().AddAsync(uomdata);
            }
            await _unitOfMeasure.SaveAsync();
        }
        public async Task DeleteUOM(UnitOfMeasureDeleteRequest deleteRequest)
        {
            var uom = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(uom => uom.Id == deleteRequest.Id);
            if (uom == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {uom.Id} not found.");
            }
            uom.State = StateEnum.deleted;
            await _unitOfMeasure.Repository<UnitOfMeasure>().Update(uom);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task AddRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure)
        {
            var data = _mapper.Map<IEnumerable<UnitOfMeasure>>(unitOfMeasure);
            await _unitOfMeasure.Repository<UnitOfMeasure>().AddRange(data);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task Update(UnitOfMeasureUpdateRequestDto unitOfMeasure)
        {
            var existingData = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(u => u.Id == unitOfMeasure.Id);
            var translationsData = await _unitOfMeasure.Repository<UnitOfMeasureTranslations>()
                .Get(uom => uom.Id == unitOfMeasure.Id && uom.LanguageId == unitOfMeasure.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {unitOfMeasure.Id} not found.");
            }
            existingData.ShortText = unitOfMeasure.ShortText;
            existingData.LongText = unitOfMeasure.LongText;
            existingData.Code = unitOfMeasure.Code;
            existingData.State = unitOfMeasure.State;
            existingData.Name = unitOfMeasure.Name;
            existingData.OrganizationId = unitOfMeasure.OrganizationId;

            translationsData.ShortText = unitOfMeasure.ShortText;
            translationsData.LongText = unitOfMeasure.LongText;
            translationsData.State = unitOfMeasure.State;
            translationsData.Name = unitOfMeasure.Name;

            await _unitOfMeasure.Repository<UnitOfMeasure>().Update(existingData);
            await _unitOfMeasure.Repository<UnitOfMeasureTranslations>().Update(translationsData);
            await _unitOfMeasure.SaveAsync();

        }
        public async Task UpdateRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure)
        {
            var data = _mapper.Map<IEnumerable<UnitOfMeasure>>(unitOfMeasure);
            await _unitOfMeasure.Repository<UnitOfMeasure>().UpdateRange(data);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAll()
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().GetAll();
            var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(lst);
            return data;
        }
        public async Task<UnitOfMeasureResponseDto> GetById(long Id)
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(u => u.Id == Id);
            var data = _mapper.Map<UnitOfMeasureResponseDto>(lst);
            return data;
        }
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMByUOMTypeId(long uomTypeId)
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().GetAll(u => u.UnitOfMeasureTypeId == uomTypeId);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(lst);
            return data;
        }

        public async Task<long> Count()
        {
            var count = await _unitOfMeasure.Repository<UnitOfMeasure>().Count();
            return count;
        }

        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslations(long id)
        {
            var list = await _unitOfMeasure.UnitOfMeasure.GetAllUOMTranslations(id);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(list);
            return data;
        }
    }
}
