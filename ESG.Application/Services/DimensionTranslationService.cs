﻿using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DimensionTranslation;
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
    public class DimensionTranslationService : IDimensionTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DimensionTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(DimensionTranslationCreateRequestDto requestDto)
        {
            if (requestDto != null)
            {
                var existingTranslation = await _unitOfWork.Repository<DimensionTranslation>()
                    .Get(a => a.DimensionsId == requestDto.DimensionId && a.LanguageId == requestDto.LanguageId);
                if (existingTranslation != null)
                {
                    existingTranslation.LanguageId = requestDto.LanguageId;
                    existingTranslation.ShortText = requestDto.ShortText;
                    existingTranslation.LongText = requestDto.LongText;
                    existingTranslation.State = requestDto.State;
                    existingTranslation.LastModifiedBy = requestDto.UserId;
                    existingTranslation.LastModifiedDate = DateTime.UtcNow;
                    await _unitOfWork.Repository<DimensionTranslation>().UpdateAsync(existingTranslation.Id, existingTranslation);
                }
                if (existingTranslation == null)
                {
                    var translationdata = new DimensionTranslation();
                    translationdata.LanguageId = requestDto.LanguageId;
                    translationdata.ShortText = requestDto.ShortText;
                    translationdata.LongText = requestDto.LongText;
                    translationdata.State = requestDto.State;
                    translationdata.LastModifiedBy = requestDto.UserId;
                    translationdata.LastModifiedDate = DateTime.UtcNow;
                    translationdata.CreatedBy = requestDto.UserId;
                    translationdata.CreatedDate = DateTime.UtcNow;
                    await _unitOfWork.Repository<DimensionTranslation>().AddAsync(translationdata);
                }
            }
            await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<Dimension>> GetDimensionTranslationsByDimensionTypeId(long dimensionTypeId, long languageId, long organizationId)
        {
            var list = await _unitOfWork.DimensionRepo.GetDimensionTranslationsByDimensionId(dimensionTypeId, languageId,organizationId);
            return list;
        }
    }
}
