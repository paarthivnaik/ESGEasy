using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataPointValueTranslation;
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
    public class DataPointValueTranslationService : IDataPointValueTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DataPointValueTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(DataPointValueTranslationCreateRequestDto requestDto)
        {
            if (requestDto != null)
            {
                var existingTranslation = await _unitOfWork.Repository<DatapointValueTranslation>()
                    .Get(a => a.DatapointValueId == requestDto.DatapointValueId && a.LanguageId == requestDto.LanguageId);
                if (existingTranslation != null)
                {
                    existingTranslation.LanguageId = requestDto.LanguageId;
                    existingTranslation.ShortText = requestDto.ShortText;
                    existingTranslation.LongText = requestDto.LongText;
                    existingTranslation.State = requestDto.State;
                    existingTranslation.LastModifiedBy = requestDto.UserId;
                    existingTranslation.LastModifiedDate = DateTime.UtcNow;
                    existingTranslation.Name = requestDto.Name;
                    await _unitOfWork.Repository<DatapointValueTranslation>().UpdateAsync(existingTranslation.Id, existingTranslation);
                }
                if (existingTranslation == null)
                {
                    var uomTranslationdata = new DatapointValueTranslation();
                    uomTranslationdata.LanguageId = requestDto.LanguageId;
                    uomTranslationdata.Name = requestDto.Name;
                    uomTranslationdata.ShortText = requestDto.ShortText;
                    uomTranslationdata.LongText = requestDto.LongText;
                    uomTranslationdata.State = requestDto.State;
                    uomTranslationdata.CreatedBy = requestDto.UserId;
                    uomTranslationdata.CreatedDate = DateTime.UtcNow;
                    uomTranslationdata.State = requestDto.State;
                    uomTranslationdata.LastModifiedBy = requestDto.UserId;
                    uomTranslationdata.LastModifiedDate = DateTime.UtcNow;
                    await _unitOfWork.Repository<DatapointValueTranslation>().AddAsync(uomTranslationdata);
                }
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
