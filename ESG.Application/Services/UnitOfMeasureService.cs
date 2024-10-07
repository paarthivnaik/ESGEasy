using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;
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
        public async Task Add(List<UnitOfMeasureCreateRequestDto> unitOfMeasures)
        {
            var oldUoms = new List<UnitOfMeasure>();
            var newUoms = new List<UnitOfMeasure>();
            if (unitOfMeasures != null)
            {
                foreach(var uom in unitOfMeasures)
                {
                    if (uom.UnitOfMeasureId > 0)
                    {
                        var existingUOM = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(a => a.Id == uom.UnitOfMeasureId);
                        existingUOM.Name = uom.Name;
                        existingUOM.ShortText = uom.ShortText;
                        existingUOM.LongText = uom.LongText;
                        existingUOM.OrganizationId = uom.OrganizationId;
                        existingUOM.LanguageId = uom.LanguageId;
                        existingUOM.UnitOfMeasureTypeId = uom.UnitOfMeasureTypeId;
                        existingUOM.CreatedBy = uom.UserId;
                        existingUOM.LastModifiedBy = uom.UserId;
                        existingUOM.CreatedDate = DateTime.UtcNow;
                        existingUOM.LastModifiedDate = DateTime.UtcNow;
                        existingUOM.State = StateEnum.active;
                        oldUoms.Add(existingUOM);
                        //var uomTranslationdataOnly = _mapper.Map<UnitOfMeasureTranslation>(unitOfMeasures);
                        //await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().AddAsync(uomTranslationdataOnly);
                    }
                    else
                    {
                        var uomdata = new UnitOfMeasure
                        {
                            Code = uom.Code,
                            Name = uom.Name,
                            ShortText = uom.ShortText,
                            LongText = uom.LongText,
                            OrganizationId = uom.OrganizationId,
                            LanguageId = uom.LanguageId,
                            UnitOfMeasureTypeId = uom.UnitOfMeasureTypeId,
                            CreatedBy = uom.UserId,
                            LastModifiedBy = uom.UserId,
                            CreatedDate = DateTime.UtcNow,
                            LastModifiedDate = DateTime.UtcNow,
                            State = StateEnum.active
                        };
                        newUoms.Add(uomdata);
                        //var uomTranslationdata = _mapper.Map<UnitOfMeasureTranslation>(unitOfMeasures);
                        //uomTranslationdata.UnitOfMeasureId = uomdata.DatapointId;
                        //uomdata.UnitOfMeasureTranslation = new List<UnitOfMeasureTranslation> { uomTranslationdata };
                    }
                }
            }
            await _unitOfMeasure.Repository<UnitOfMeasure>().UpdateRange(oldUoms);
            await _unitOfMeasure.Repository<UnitOfMeasure>().AddRange(newUoms);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task DeleteUOM(UnitOfMeasureDeleteRequest deleteRequest)
        {
            var uom = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(uom => uom.Id == deleteRequest.Id);
            if (uom == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {uom.Id} not found.");
            }
            uom.State = deleteRequest.State;
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
            var existingData = await _unitOfMeasure.Repository<UnitOfMeasure>()
                .Get(u => u.Id == unitOfMeasure.Id && u.LanguageId == unitOfMeasure.LanguageId);
            //var translationsData = await _unitOfMeasure.Repository<UnitOfMeasureTranslation>()
            //    .Get(uom => uom.UnitOfMeasureId == unitOfMeasure.Id && uom.LanguageId == unitOfMeasure.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {unitOfMeasure.Id} not found.");
            }
            existingData.ShortText = unitOfMeasure.ShortText;
            existingData.LongText = unitOfMeasure.LongText;
            //existingData.Code = unitOfMeasure.Code;
            existingData.State = unitOfMeasure.State;
            existingData.Name = unitOfMeasure.Name;
            existingData.OrganizationId = unitOfMeasure.OrganizationId;

            //translationsData.ShortText = unitOfMeasure.ShortText;
            //translationsData.LongText = unitOfMeasure.LongText;
            //translationsData.State = unitOfMeasure.State;
            //translationsData.Name = unitOfMeasure.Name;

            await _unitOfMeasure.Repository<UnitOfMeasure>().Update(existingData);
            //await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().Update(translationsData);
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
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().GetAll(a => a.State == StateEnum.active);
            var orderedList = lst.OrderBy(u => u.Id);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(orderedList);
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
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().GetAll(u => u.UnitOfMeasureTypeId == uomTypeId && u.State == StateEnum.active);
            var orderedList = lst.OrderBy(u => u.Id);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(orderedList);
            return data;
        }

        public async Task<long> Count()
        {
            var count = await _unitOfMeasure.Repository<UnitOfMeasure>().Count();
            return count;
        }

        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslationsByUOMId(long id)
        {
            var list = await _unitOfMeasure.UnitOfMeasure.GetAllUOMTranslationsByUOMId(id);
            var orderedList = list.OrderBy(u => u.Id);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(orderedList);
            return data;
        }
    }
}
