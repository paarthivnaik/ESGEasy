﻿using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Dimensions;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DimensionsService : IDimensionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DimensionsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(List<DimensionCreateRequestDto> dimentions)
        {
            var olddimensions = new List<Dimensions>();
            var newdimensions = new List<Dimensions>();
            if (dimentions != null)
            {
                foreach (var dimention in dimentions)
                {
                    if (dimention.DimensionsId > 0)
                    {
                        var existingDimension = await _unitOfWork.Repository<Dimensions>().Get(a => a.Id == dimention.DimensionsId);
                        existingDimension.DimensionTypeId = dimention.DimensionTypeId;
                        existingDimension.LanguageId = dimention.LanguageId;
                        existingDimension.OrganizationId = dimention.OrganizationId;
                        existingDimension.ShortText = dimention.ShortText;
                        existingDimension.LongText = dimention.LongText;
                        olddimensions.Add(existingDimension);                        

                        //var dimensionsTranslateddata = _mapper.Map<DimensionTranslations>(dimentions);
                        //await _unitOfWork.Repository<DimensionTranslations>().AddAsync(dimensionsTranslateddata);
                    }
                    else
                    {
                        var dimensonsdata = _mapper.Map<Dimensions>(dimention);
                        //var dimensonsTranslationdata = _mapper.Map<DimensionTranslations>(dimentions);
                        //dimensonsTranslationdata.DimensionsId = dimensonsdata.DatapointId;
                        //dimensonsdata.DimensionTranslations = new List<DimensionTranslations> { dimensonsTranslationdata };
                        newdimensions.Add(dimensonsdata);
                    }
                }
            }
            await _unitOfWork.Repository<Dimensions>().AddRange(newdimensions);
            await _unitOfWork.Repository<Dimensions>().UpdateRange(olddimensions);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(DimensionsDeleteRequestDto request)
        {
            var dimension = await _unitOfWork.Repository<Dimensions>().Get(uom => uom.Id == request.Id);
            if (dimension == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {dimension.Id} not found.");
            }
            dimension.State = StateEnum.deleted;
            await _unitOfWork.Repository<Dimensions>().Update(dimension);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionsResponseDto>> GetAll()
        {
            var list = await _unitOfWork.Repository<Dimensions>().GetAll();
            return _mapper.Map<IEnumerable<DimensionsResponseDto>>(list);
        }

        public async Task<IEnumerable<DimensionsResponseDto>> GetById(long Id)
        {
            var list = await _unitOfWork.Repository<Dimensions>().GetAll(d => d.DimensionTypeId == Id);
            return _mapper.Map<IEnumerable<DimensionsResponseDto>>(list);
        }

        public async Task UpdateAsync(DimensionsUpdateRequestDto dimentionsRequest)
        {
            var existingData = await _unitOfWork.Repository<Dimensions>()
                .Get(u => u.Id == dimentionsRequest.Id && u.LanguageId == dimentionsRequest.LanguageId);
            var translationsData = await _unitOfWork.Repository<DimensionTranslations>()
                .Get(uom => uom.DimensionsId == dimentionsRequest.Id && uom.LanguageId == dimentionsRequest.LanguageId);
            if (existingData == null || translationsData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {dimentionsRequest.Id} not found.");
            }
            if (existingData != null)
            {
                existingData.ShortText = dimentionsRequest.ShortText;
                existingData.LongText = dimentionsRequest.LongText;
                existingData.Code = dimentionsRequest.Code;
                existingData.State = dimentionsRequest.State;
            }
            if (translationsData != null)
            {
                translationsData.ShortText = dimentionsRequest.ShortText;
                translationsData.LongText = dimentionsRequest.LongText;
                translationsData.State = dimentionsRequest.State;
            }
            await _unitOfWork.Repository<Dimensions>().Update(existingData);
            await _unitOfWork.Repository<DimensionTranslations>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionsResponseDto>> GetAllTranslations(long id)
        {
            var list = await _unitOfWork.DimensionRepo.GetAllTranslations(id);
            return _mapper.Map<IEnumerable<DimensionsResponseDto>>(list);
        }
    }
}

