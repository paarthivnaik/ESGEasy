using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;

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
        public async Task Add(UnitOfMeasureDto unitOfMeasure)
        {
            if (unitOfMeasure.UnitOfMeasureId > 0)
            {
                var uomTranslationdataOnly = _mapper.Map<UnitOfMeasureTranslations>(unitOfMeasure);
                await _unitOfMeasure.Repository<UnitOfMeasureTranslations>().AddAsync(uomTranslationdataOnly);
            }
            else
            {
                var uomdata = _mapper.Map<UnitOfMeasure>(unitOfMeasure);
                var uomTranslationdata = _mapper.Map<UnitOfMeasureTranslations>(unitOfMeasure);
                await _unitOfMeasure.Repository<UnitOfMeasure>().AddAsync(uomdata);
                uomdata.UnitOfMeasureTranslations = new List<UnitOfMeasureTranslations> { uomTranslationdata };
            }
            
            await _unitOfMeasure.SaveAsync();
        }

        public async Task AddRange(IEnumerable<UnitOfMeasureDto> unitOfMeasure)
        {
            var data = _mapper.Map<IEnumerable<UnitOfMeasure>>(unitOfMeasure);
            await _unitOfMeasure.Repository<UnitOfMeasure>().AddRange(data);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task Update(UnitOfMeasureDto unitOfMeasure)
        {

            var data = _mapper.Map<UnitOfMeasure>(unitOfMeasure);
            var existingData = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(u=>u.Id==unitOfMeasure.Id && u.OrganizationId==unitOfMeasure.OrganizationId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"Unit of Measure with ID {unitOfMeasure.Id} not found.");
            }
            existingData.ShortText = unitOfMeasure.ShortText;
            existingData.LongText = unitOfMeasure.LongText;
            existingData.UnitOfMeasureTypeId = unitOfMeasure.UnitOfMeasureTypeId;

            await _unitOfMeasure.Repository<UnitOfMeasure>().Update(existingData);
            //await _unitOfMeasure.Repository<UnitOfMeasure>().UpdateFieldsSave(data,c=>c.UnitOfMeasureTypeId,c=>c.LongText, c=>c.ShortText);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task UpdateRange(IEnumerable<UnitOfMeasureDto> unitOfMeasure)
        {
            var data = _mapper.Map<IEnumerable<UnitOfMeasure>>(unitOfMeasure);
            await _unitOfMeasure.Repository<UnitOfMeasure>().UpdateRange(data);
            await _unitOfMeasure.SaveAsync();
        }
        public async Task<IEnumerable<UnitOfMeasureDto>> GetAll()
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().GetAll();
            var data = _mapper.Map<IEnumerable<UnitOfMeasureDto>>(lst);
            return data;
        }
        public async Task<UnitOfMeasureDto> GetById(long Id)
        {
            var lst = await _unitOfMeasure.Repository<UnitOfMeasure>().Get(u => u.Id == Id && u.OrganizationId ==1);
            var data = _mapper.Map<UnitOfMeasureDto>(lst);
            return data;
        }

        public async Task<long> Count()
        {
            var count = await _unitOfMeasure.Repository<UnitOfMeasure>().Count();
            return count;
        }

       
    }
}
