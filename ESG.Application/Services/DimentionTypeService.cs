using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DimentionTypeService : IDimentionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DimentionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(DimensionTypeCreateRequestDto dimentionType)
        {
            if (dimentionType.DimensionTypeId > 0)
            {
                var dimensionsTranslateddata = _mapper.Map<DimensionTypeTranslations>(dimentionType);
                await _unitOfWork.Repository<DimensionTypeTranslations>().AddAsync(dimensionsTranslateddata);
            }
            else
            {
                var dimensonsdata = _mapper.Map<DimensionType>(dimentionType);
                var dimensonsTranslationdata = _mapper.Map<DimensionTypeTranslations>(dimentionType);
                dimensonsTranslationdata.DimensionTypeId = dimensonsdata.Id;
                dimensonsdata.DimensionTypeTranslations = new List<DimensionTypeTranslations> { dimensonsTranslationdata };
                await _unitOfWork.Repository<DimensionType>().AddAsync(dimensonsdata);
            }
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(DimensionTypeUpdateRequestDto dimentionType)
        {
            //var res = await _unitOfWork.Repository<DimensionType>().Update(dimentionType);
            //await _unitOfWork.SaveAsync();
            //return res;
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DimensionType>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DimensionType>> GetAll()
        {
            return await _unitOfWork.Repository<DimensionType>().GetAll();
        }

        public async Task<DimensionType> GetById(long Id)
        {
            return await _unitOfWork.Repository<DimensionType>().Get(Id);
        }
    }
}
