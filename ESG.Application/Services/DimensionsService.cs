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
            var oldDimension = new List<Dimension>();
            var newDimension = new List<Dimension>();
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
                        oldDimension.Add(existingDimension);                        

                        //var DimensionTranslateddata = _mapper.Map<DimensionTranslation>(dimentions);
                        //await _unitOfWork.Repository<DimensionTranslation>().AddAsync(DimensionTranslateddata);
                    }
                    else
                    {
                        var dimensonsdata = _mapper.Map<Dimension>(dimention);
                        //var dimensonsTranslationdata = _mapper.Map<DimensionTranslation>(dimentions);
                        //dimensonsTranslationdata.DimensionId = dimensonsdata.DatapointId;
                        //dimensonsdata.DimensionTranslation = new List<DimensionTranslation> { dimensonsTranslationdata };
                        newDimension.Add(dimensonsdata);
                    }
                }
            }
            await _unitOfWork.Repository<Dimension>().AddRange(newDimension);
            await _unitOfWork.Repository<Dimension>().UpdateRange(oldDimension);
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

        public async Task<IEnumerable<DimensionResponseDto>> GetAll()
        {
            var list = await _unitOfWork.Repository<Dimension>().GetAll(a => a.State == StateEnum.active);
            return _mapper.Map<IEnumerable<DimensionResponseDto>>(list);
        }

        public async Task<IEnumerable<DimensionResponseDto>> GetById(long Id)
        {
            var list = await _unitOfWork.Repository<Dimension>().GetAll(d => d.DimensionTypeId == Id);
            return _mapper.Map<IEnumerable<DimensionResponseDto>>(list);
        }

        public async Task UpdateAsync(DimensionUpdateRequestDto dimentionsRequest)
        {
            var existingData = await _unitOfWork.Repository<Dimension>()
                .Get(u => u.Id == dimentionsRequest.Id && u.LanguageId == dimentionsRequest.LanguageId);
            var translationsData = await _unitOfWork.Repository<DimensionTranslation>()
                .Get(uom => uom.DimensionsId == dimentionsRequest.Id && uom.LanguageId == dimentionsRequest.LanguageId);
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
            if (translationsData != null)
            {
                translationsData.ShortText = dimentionsRequest.ShortText;
                translationsData.LongText = dimentionsRequest.LongText;
                translationsData.State = dimentionsRequest.State;
            }
            await _unitOfWork.Repository<Dimension>().Update(existingData);
            await _unitOfWork.Repository<DimensionTranslation>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionResponseDto>> GetAllTranslations(long id)
        {
            var list = await _unitOfWork.DimensionRepo.GetAllTranslations(id);
            return _mapper.Map<IEnumerable<DimensionResponseDto>>(list);
        }
    }
}

