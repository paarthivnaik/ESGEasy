using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Dimension;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DimensionService : IDimensionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DimensionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(List<DimensionCreateRequestDto> dimentions)
        {
            var oldDimensions = new List<Dimension>();
            var oldDimensionTranslations = new List<DimensionTranslation>();
            var newDimensionTranslations = new List<DimensionTranslation>();
            var newDimensions = new List<Dimension>();
            if (dimentions != null)
            {
                foreach (var dimention in dimentions)
                {
                    if (dimention.DimensionId > 0)
                    {
                        var existingDimension = await _unitOfWork.Repository<Dimension>().Get(a => a.Id == dimention.DimensionId);
                        existingDimension.DimensionTypeId = dimention.DimensionTypeId;
                        existingDimension.LanguageId = dimention.LanguageId;
                        existingDimension.OrganizationId = dimention.OrganizationId;
                        existingDimension.ShortText = dimention.ShortText;
                        existingDimension.LongText = dimention.LongText;
                        existingDimension.LastModifiedBy = dimention.UserId;
                        existingDimension.LastModifiedDate = DateTime.UtcNow;
                        oldDimensions.Add(existingDimension); 

                        var existingDimensionTranslation = await _unitOfWork.Repository<DimensionTranslation>()
                            .Get(a => a.DimensionsId == dimention.DimensionId && a.LanguageId == dimention.LanguageId);
                        existingDimensionTranslation.LanguageId = dimention.LanguageId;
                        existingDimensionTranslation.ShortText = dimention.ShortText;
                        existingDimensionTranslation.LongText = dimention.LongText;
                        existingDimensionTranslation.LastModifiedBy = dimention.UserId;
                        existingDimensionTranslation.LastModifiedDate = DateTime.UtcNow;
                        oldDimensionTranslations.Add(existingDimensionTranslation);                        
                    }
                    else
                    {
                        var code = dimention.Code.ToUpper();
                        var existingdimensionCode = await _unitOfWork.Repository<Dimension>()
                            .Get(a => a.DimensionTypeId == dimention.DimensionTypeId && a.Code == code 
                                && a.State == Domain.Enum.StateEnum.active
                                && a.OrganizationId == dimention.OrganizationId);
                        if (existingdimensionCode != null)
                        {
                            throw new System.Exception($"The Datapoint with code - {dimention.Code} already exists");
                        }
                        var dimensonsdata = _mapper.Map<Dimension>(dimention);
                        dimensonsdata.State = StateEnum.active;
                        dimensonsdata.Code = code;
                        var dimensonsTranslationdata = new DimensionTranslation();
                        dimensonsTranslationdata.ShortText = dimention.ShortText;
                        dimensonsTranslationdata.LongText = dimention.LongText;
                        dimensonsTranslationdata.LanguageId = dimention.LanguageId;
                        dimensonsTranslationdata.CreatedBy = dimention.UserId;
                        dimensonsTranslationdata.LastModifiedBy = dimention.UserId;
                        dimensonsTranslationdata.CreatedDate = DateTime.UtcNow;
                        dimensonsTranslationdata.LastModifiedDate = DateTime.UtcNow;
                        dimensonsTranslationdata.DimensionsId = dimensonsdata.Id;
                        dimensonsdata.DimensionTranslations = new List<DimensionTranslation> { dimensonsTranslationdata };
                        newDimensions.Add(dimensonsdata);
                    }
                }
            }
            await _unitOfWork.Repository<Dimension>().AddRangeAsync(newDimensions);
            await _unitOfWork.Repository<DimensionTranslation>().AddRangeAsync(newDimensionTranslations);
            await _unitOfWork.Repository<Dimension>().UpdateRange(oldDimensions);
            await _unitOfWork.Repository<DimensionTranslation>().AddRangeAsync(oldDimensionTranslations);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(DimensionDeleteRequestDto request)
        {
            var dimension = await _unitOfWork.Repository<Dimension>().Get(uom => uom.Id == request.Id);
            if (dimension == null)
            {
                throw new KeyNotFoundException($"Dimension with ID {dimension.Id} not found.");
            }
            dimension.State = request.State;
            await _unitOfWork.Repository<Dimension>().Update(dimension);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionResponseDto>> GetAll(long organizationId)
        {
            var list = await _unitOfWork.Repository<Dimension>().GetAll
                (a => (a.OrganizationId == 1 || a.OrganizationId == organizationId) && a.State == StateEnum.active);
            return _mapper.Map<IEnumerable<DimensionResponseDto>>(list);
        }

        public async Task<IEnumerable<DimensionResponseDto>> GetById(long Id, long organizationId)
        {
            var list = await _unitOfWork.Repository<Dimension>().GetAll
                (d => (d.OrganizationId == 1 || d.OrganizationId == organizationId) && d.DimensionTypeId == Id && d.State == StateEnum.active);
            return _mapper.Map<IEnumerable<DimensionResponseDto>>(list);
        }

        public async Task UpdateAsync(DimensionUpdateRequestDto dimentionsRequest)
        {
            var existingData = await _unitOfWork.Repository<Dimension>()
                .Get(u => u.Id == dimentionsRequest.Id && u.LanguageId == dimentionsRequest.LanguageId);
            //var translationsData = await _unitOfWork.Repository<DimensionTranslation>()
            //    .Get(uom => uom.DimensionsId == dimentionsRequest.Id && uom.LanguageId == dimentionsRequest.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Dimension with ID {dimentionsRequest.Id} not found.");
            }
            if (existingData != null)
            {
                existingData.ShortText = dimentionsRequest.ShortText;
                existingData.LongText = dimentionsRequest.LongText;
                existingData.Code = dimentionsRequest.Code;
                existingData.State = dimentionsRequest.State;
            }
            //if (translationsData != null)
            //{
            //    translationsData.ShortText = dimentionsRequest.ShortText;
            //    translationsData.LongText = dimentionsRequest.LongText;
            //    translationsData.State = dimentionsRequest.State;
            //}
            await _unitOfWork.Repository<Dimension>().Update(existingData);
            //await _unitOfWork.Repository<DimensionTranslation>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionResponseDto>> GetAllTranslations(long id)
        {
            var list = await _unitOfWork.DimensionRepo.GetAllTranslations(id);
            return _mapper.Map<IEnumerable<DimensionResponseDto>>(list);
        }
    }
}

