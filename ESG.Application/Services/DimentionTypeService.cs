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
            //if (dimentionType.DimensionTypeId > 0)
            //{
            //    var dimensionsTranslateddata = _mapper.Map<DimensionTypeTranslations>(dimentionType);
            //    await _unitOfWork.Repository<DimensionTranslations>().AddAsync(dimensionsTranslateddata);
            //}
            //else
            //{
            //    var dimensonsdata = _mapper.Map<Dimensions>(dimentions);
            //    var dimensonsTranslationdata = _mapper.Map<DimensionTranslations>(dimentions);
            //    dimensonsTranslationdata.DimensionsId = dimensonsdata.Id;
            //    dimensonsdata.DimensionTranslations = new List<DimensionTranslations> { dimensonsTranslationdata };
            //    await _unitOfWork.Repository<Dimensions>().AddAsync(dimensonsdata);
            //}
            //await _unitOfWork.SaveAsync();
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
