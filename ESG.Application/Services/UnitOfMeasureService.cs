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
            var oldUomTranslations = new List<UnitOfMeasureTranslation>();
            var newUoms = new List<UnitOfMeasure>();
            var newUomTranslations = new List<UnitOfMeasureTranslation>();
            if (unitOfMeasures != null)
            {
                foreach(var uom in unitOfMeasures)
                {
                    if (uom.UnitOfMeasureId > 0)
                    {
                        var existingUOM = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(a => a.Id == uom.UnitOfMeasureId);
                        existingUOM.ShortText = uom.ShortText;
                        existingUOM.LongText = uom.LongText;
                        existingUOM.OrganizationId = uom.OrganizationId;
                        existingUOM.LanguageId = uom.LanguageId;
                        existingUOM.UnitOfMeasureTypeId = uom.UnitOfMeasureTypeId;
                        existingUOM.LastModifiedBy = uom.UserId;
                        existingUOM.LastModifiedDate = DateTime.UtcNow;
                        existingUOM.State = StateEnum.active;
                        oldUoms.Add(existingUOM);

                        var existingUOMTranslation = await _unitOfMeasure.Repository<UnitOfMeasureTranslation>()
                            .Get(a => a.UnitOfMeasureId == uom.UnitOfMeasureId && a.LanguageId == uom.LanguageId);
                        existingUOMTranslation.ShortText = uom.ShortText;
                        existingUOMTranslation.LongText = uom.LongText;
                        existingUOMTranslation.LanguageId = uom.LanguageId;
                        existingUOMTranslation.LastModifiedBy = uom.UserId;
                        existingUOMTranslation.LastModifiedDate = DateTime.UtcNow;
                        existingUOMTranslation.State = StateEnum.active;
                        oldUomTranslations.Add(existingUOMTranslation);
                    }
                    else
                    {
                        var code = uom.Code.ToUpper();
                        var existingCode = await _unitOfMeasure.Repository<UnitOfMeasure>()
                            .Get(a => a.UnitOfMeasureTypeId == uom.UnitOfMeasureTypeId 
                            && a.Code.ToUpper() == code && a.State == Domain.Enum.StateEnum.active 
                            && (a.OrganizationId == 1 || a.OrganizationId == uom.OrganizationId));
                        if (existingCode != null)
                        {
                            throw new System.Exception($"The Datapoint with code - {uom.Code} already exists");
                        }
                        var uomdata = new UnitOfMeasure
                        {
                            Code = code,
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
                        var uomTranslation = new UnitOfMeasureTranslation
                        {
                            UnitOfMeasureId = uomdata.Id,
                            LanguageId = uomdata.LanguageId,
                            ShortText = uomdata.ShortText,
                            LongText = uomdata.LongText,
                            State = StateEnum.active,
                            CreatedBy = uomdata.CreatedBy,
                            LastModifiedBy= uomdata.CreatedBy,
                            CreatedDate = DateTime.UtcNow,
                            LastModifiedDate = DateTime.UtcNow,
                        };
                        uomTranslation.UnitOfMeasureId = uomdata.Id;
                        uomdata.UnitOfMeasureTranslations = new List<UnitOfMeasureTranslation> { uomTranslation };
                        newUomTranslations.Add(uomTranslation);
                    }
                }
            }
            await _unitOfMeasure.Repository<UnitOfMeasure>().UpdateRange(oldUoms);
            await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().UpdateRange(oldUomTranslations);
            await _unitOfMeasure.Repository<UnitOfMeasure>().AddRangeAsync(newUoms);
            await _unitOfMeasure.Repository<UnitOfMeasureTranslation>().AddRangeAsync(newUomTranslations);
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
            await _unitOfMeasure.Repository<UnitOfMeasure>().AddRangeAsync(data);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task Update(UnitOfMeasureUpdateRequestDto unitOfMeasure)
        {
            var existingData = await _unitOfMeasure.Repository<UnitOfMeasure>()
                .Get(u => u.Id == unitOfMeasure.Id && u.LanguageId == unitOfMeasure.LanguageId);
            //var translationsData = await _unitOfWork.Repository<UnitOfMeasureTranslation>()
            //    .Get(uom => uom.UnitOfMeasureId == unitOfMeasure.Id && uom.LanguageId == unitOfMeasure.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {unitOfMeasure.Id} not found.");
            }
            existingData.ShortText = unitOfMeasure.ShortText;
            existingData.LongText = unitOfMeasure.LongText;
            //existingData.Code = unitOfMeasure.Code;
            existingData.State = unitOfMeasure.State;
            existingData.OrganizationId = unitOfMeasure.OrganizationId;

            //translationsData.ShortText = unitOfMeasure.ShortText;
            //translationsData.LongText = unitOfMeasure.LongText;
            //translationsData.State = unitOfMeasure.State;
            //translationsData.Name = unitOfMeasure.Name;
           
            await _unitOfMeasure.Repository<UnitOfMeasure>().Update(existingData);
            //await _unitOfWork.Repository<UnitOfMeasureTranslation>().Update(translationsData);
            await _unitOfMeasure.SaveAsync();

        }
        public async Task UpdateRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure)
        {
            var data = _mapper.Map<IEnumerable<UnitOfMeasure>>(unitOfMeasure);
            await _unitOfMeasure.Repository<UnitOfMeasure>().UpdateRange(data);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAll(long organizationId)
        {
            var lst = await _unitOfMeasure.UnitOfMeasure.GetAllUOMDetails(organizationId);
            var orderedList = lst.OrderBy(u => u.Id);
            var data = new List<UnitOfMeasureResponseDto>();
            foreach (var item in orderedList)
            {
                var uom = new UnitOfMeasureResponseDto
                {
                    Id = item.Id,
                    Code = item.Code,
                    ShortText = item.ShortText,
                    LongText = item.LongText,
                    LanguageId = item.LanguageId,
                    State = item.State,
                    UserId = item.CreatedBy,
                    OrganizationId = item.OrganizationId,
                    UOMTypeId = item.UnitOfMeasureType.Id,
                    UomTypeName = item.UnitOfMeasureType.ShortText,
                };
                data.Add(uom);
            }
            return data;
        }
        public async Task<UnitOfMeasureResponseDto> GetById(long Id)
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(u => u.Id == Id);
            var data = _mapper.Map<UnitOfMeasureResponseDto>(lst);
            return data;
        }
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMByUOMTypeId(long uomTypeId, long organizationId)
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().GetAll
                (u => (u.OrganizationId == 1 || u.OrganizationId == organizationId) && u.UnitOfMeasureTypeId == uomTypeId && u.State == StateEnum.active);
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
