using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DimensionTypeTranslation;
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
    public class DimensionTypeTranslationService : IDimensionTypeTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DimensionTypeTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(DimensionTypeTranslationCreateRequestDto requestDto)
        {
            if (requestDto != null)
            {
                var existingTranslation = await _unitOfWork.Repository<DimensionTypeTranslation>()
                    .Get(a => a.DimensionTypeId == requestDto.DimensiontypeId && a.LanguageId == requestDto.LanguageId);
                if (existingTranslation != null)
                {
                    existingTranslation.LanguageId = requestDto.LanguageId;
                    existingTranslation.ShortText = requestDto.ShortText;
                    existingTranslation.LongText = requestDto.LongText;
                    existingTranslation.State = requestDto.State;
                    existingTranslation.LastModifiedBy = requestDto.UserId;
                    existingTranslation.LastModifiedDate = DateTime.UtcNow;
                    await _unitOfWork.Repository<DimensionTypeTranslation>().UpdateAsync(existingTranslation.Id, existingTranslation);
                }
                if (existingTranslation == null)
                {
                    var uomTranslationdata = _mapper.Map<DimensionTypeTranslation>(requestDto);
                    uomTranslationdata.State = requestDto.State;
                    uomTranslationdata.LastModifiedBy = requestDto.UserId;
                    uomTranslationdata.LastModifiedDate = DateTime.UtcNow;
                    uomTranslationdata.CreatedDate = DateTime.UtcNow;
                    await _unitOfWork.Repository<DimensionTypeTranslation>().AddAsync(uomTranslationdata);
                }
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
