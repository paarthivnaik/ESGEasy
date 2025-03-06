using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;
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

        public async Task Add(List<UnitOfMeasureTypeCreateRequestDto> unitOfMeasureType)
        {
            var oldUomTypes = new List<UnitOfMeasureType>();
            var newUomTypes = new List<UnitOfMeasureType>();
            if (unitOfMeasureType != null)
            {
                foreach (var uomType in unitOfMeasureType)
                {
                    if (uomType.UnitOfMeasureTypeId > 0)
                    {
                        var existingUOMtype = await _unitOfWork.Repository<UnitOfMeasureType>().Get(a => a.Id == uomType.UnitOfMeasureTypeId);
                        existingUOMtype.ShortText = uomType.ShortText;
                        existingUOMtype.LongText = uomType.LongText;
                        existingUOMtype.LanguageId = uomType.LanguageId;
                        existingUOMtype.OrganizationId = uomType.OrganizationId;
                        existingUOMtype.LastModifiedBy = uomType.UserId;
                        existingUOMtype.LastModifiedDate = DateTime.UtcNow;
                        oldUomTypes.Add(existingUOMtype);
                        //var uomTypeTranslationdata = _mapper.Map<UnitOfMeasureTypeTranslation>(unitOfMeasureType);
                        //await _unitOfWork.Repository<UnitOfMeasureTypeTranslation>().AddAsync(uomTypeTranslationdata);
                    }
                    else
                    {
                        var code = uomType.Code.ToUpper();
                        var existingCode = await _unitOfWork.Repository<UnitOfMeasureType>()
                            .Get(a => a.Code.ToUpper() == code && a.State == Domain.Enum.StateEnum.active && (a.OrganizationId == 1 || a.OrganizationId == uomType.OrganizationId));
                        if (existingCode != null)
                        {
                            throw new System.Exception($"The Datapoint with code - {uomType.Code} already exists");
                        }
                        var newuomtype = _mapper.Map<UnitOfMeasureType>(uomType);
                        newuomtype.Code = code;
                        newuomtype.State = StateEnum.active;
                        newUomTypes.Add(newuomtype);
                        //var uomTypeTranslationdata = _mapper.Map<UnitOfMeasureTypeTranslation>(unitOfMeasureType);
                        //uomTypeTranslationdata.UnitOfMeasureTypeId = uomType.DatapointId;
                        //uomType.UnitOfMeasureTypeTranslation = new List<UnitOfMeasureTypeTranslation> { uomTypeTranslationdata };

                    }
                }
            }
            await _unitOfWork.Repository<UnitOfMeasureType>().UpdateRange(oldUomTypes);
            await _unitOfWork.Repository<UnitOfMeasureType>().AddRangeAsync(newUomTypes);
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
            uomType.State = deleteRequest.State;
            await _unitOfWork.Repository<UnitOfMeasureType>().Update(uomType);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAll(long organizationId)
        {
            var list = await _unitOfWork.Repository<UnitOfMeasureType>().GetAll
                (a => (a.OrganizationId == 1 || a.OrganizationId == organizationId) && a.State == StateEnum.active);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureTypeResponseDto>>(list);
            return data;
        }

        public async Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAllTranslations(long Id)
        {
            var list = await _unitOfWork.Repository<UnitOfMeasureTypeTranslation>().GetAll(a => a.UnitOfMeasureTypeId == Id);
            var data = _mapper.Map<IEnumerable<UnitOfMeasureTypeResponseDto>>(list);
            return data;
        }

        public async Task UpdateAsync(UnitOfMeasureTypeUpdateRequestDto unitOfMeasureType)
        {
            var existingData = await _unitOfWork.Repository<UnitOfMeasureType>()
                .Get(u => u.Id == unitOfMeasureType.Id && u.LanguageId == unitOfMeasureType.LanguageId);
            //var translationsData = await _unitOfWork.Repository<UnitOfMeasureTypeTranslation>()
            //    .Get(uom => uom.UnitOfMeasureTypeId == unitOfMeasureType.Id && uom.LanguageId == unitOfMeasureType.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {unitOfMeasureType.Id} not found.");
            }
            existingData.ShortText = unitOfMeasureType.ShortText;
            existingData.LongText = unitOfMeasureType.LongText;
            existingData.State = unitOfMeasureType.State;
            existingData.OrganizationId = unitOfMeasureType.OrganizationId;

            //translationsData.ShortText = unitOfMeasureType.ShortText;
            //translationsData.LongText = unitOfMeasureType.LongText;
            //translationsData.State = unitOfMeasureType.State;
            //translationsData.Name = unitOfMeasureType.Name;

            await _unitOfWork.Repository<UnitOfMeasureType>().Update(existingData);
            //await _unitOfWork.Repository<UnitOfMeasureTypeTranslation>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<UnitOfMeasureType>> GetAllUOMTranslationsByUOMIdLangId(long langId, long organizationId)
        {
            var list = await _unitOfWork.UnitOfMeasureTypeRepo.GetAllUOMTranslationsByUOMIdLangId(langId, organizationId);            
            var orderedList = list.OrderBy(u => u.Id);
            //var data = _mapper.Map<IEnumerable<UnitOfMeasureResponseDto>>(orderedList);
            return orderedList;
        }
    }
}
