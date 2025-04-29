using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Dimension;
using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;


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

        public async Task AddAsync(List<DimensionTypeCreateRequestDto> dimentionTypes)
        {
            var oldDimensionTypes = new List<DimensionType>();
            var newDimensionTypes = new List<DimensionType>();
            var oldDimensionTypeTranslations = new List<DimensionTypeTranslation>();
            var newDimensionTypeTranslations = new List<DimensionTypeTranslation>();
            if (dimentionTypes != null)
            {
                foreach (var dimensionType in dimentionTypes)
                {
                    if (dimensionType.DimensionTypeId > 0)
                    {
                        var existingdimType = await _unitOfWork.Repository<DimensionType>().Get(a => a.Id == dimensionType.DimensionTypeId);
                        existingdimType.ShortText = dimensionType.ShortText;
                        existingdimType.LongText = dimensionType.LongText;
                        existingdimType.LanguageId = dimensionType.LanguageId;
                        existingdimType.OrganizationId = dimensionType.OrganizationId;
                        existingdimType.State = dimensionType.State;
                        existingdimType.LastModifiedBy = dimensionType.UserId;
                        existingdimType.LastModifiedDate = DateTime.UtcNow;
                        oldDimensionTypes.Add(existingdimType);

                        var existingdimTypeTranslation = await _unitOfWork.Repository<DimensionTypeTranslation>()
                            .Get(a => a.DimensionTypeId == dimensionType.DimensionTypeId && a.LanguageId == dimensionType.LanguageId);
                        existingdimTypeTranslation.ShortText = dimensionType.ShortText;
                        existingdimTypeTranslation.LongText = dimensionType.LongText;
                        existingdimTypeTranslation.LanguageId = dimensionType.LanguageId;
                        existingdimTypeTranslation.State = dimensionType.State;
                        existingdimTypeTranslation.LastModifiedBy = dimensionType.UserId;
                        existingdimTypeTranslation.LastModifiedDate = DateTime.UtcNow;
                        oldDimensionTypeTranslations.Add(existingdimTypeTranslation);
                    }
                    else
                    {
                        var code = dimensionType.Code.ToUpper();
                        var existingCode = await _unitOfWork.Repository<DimensionType>()
                            .Get(a => a.Code.ToUpper() == code 
                                && a.State == Domain.Enum.StateEnum.active
                                && (a.OrganizationId == 1 || a.OrganizationId == dimensionType.OrganizationId));
                        if (existingCode != null)
                        {
                            throw new System.Exception($"The Datapoint with code - {dimensionType.Code} already exists");
                        }
                        var dimensonsdata = _mapper.Map<DimensionType>(dimensionType);
                        dimensonsdata.State = StateEnum.active;
                        dimensonsdata.Code = code;
                        newDimensionTypes.Add(dimensonsdata);
                        var dimensonsTranslationdata = _mapper.Map<DimensionTypeTranslation>(dimensionType);
                        dimensonsTranslationdata.DimensionTypeId = dimensonsdata.Id;
                        dimensonsdata.DimensionTypeTranslations = new List<DimensionTypeTranslation> { dimensonsTranslationdata };
                        newDimensionTypeTranslations.Add(dimensonsTranslationdata);

                    }
                }
            }
            await _unitOfWork.Repository<DimensionType>().AddRangeAsync(newDimensionTypes);
            await _unitOfWork.Repository<DimensionType>().UpdateRange(oldDimensionTypes);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateAsync(DimensionTypeUpdateRequestDto dimentionType)
        {
            var existingData = await _unitOfWork.Repository<DimensionType>()
                .Get(u => u.Id == dimentionType.Id && u.LanguageId == dimentionType.LanguageId);
            var translationsData = await _unitOfWork.Repository<DimensionTypeTranslation>()
                .Get(uom => uom.DimensionTypeId == dimentionType.Id && uom.LanguageId == dimentionType.LanguageId);
            if (existingData == null)
            {
                throw new KeyNotFoundException($"DimensionType with ID {dimentionType.Id} not found.");
            }
            existingData.ShortText = dimentionType.ShortText;
            existingData.LongText = dimentionType.LongText;
            existingData.Code = dimentionType.Code;
            existingData.State = dimentionType.State;

            translationsData.ShortText = dimentionType.ShortText;
            translationsData.LongText = dimentionType.LongText;
            translationsData.State = dimentionType.State;

            await _unitOfWork.Repository<DimensionType>().Update(existingData);
            await _unitOfWork.Repository<DimensionTypeTranslation>().Update(translationsData);
            await _unitOfWork.SaveAsync();
        }

        public async Task SoftDelete(DimensionTypeDeleteRequestDto request)
        {
            var dimension = await _unitOfWork.Repository<DimensionType>().Get(uom => uom.Id == request.Id);
            if (dimension == null)
            {
                throw new KeyNotFoundException($"DimensionType ID {dimension.Id} not found.");
            }
            dimension.State = request.State;
            await _unitOfWork.Repository<DimensionType>().Update(dimension);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DimensionTypeResponseDto>> GetAll(long organizationId)
        {
            var list = await _unitOfWork.Repository<DimensionType>().GetAll
                (a => (a.OrganizationId == 1 || a.OrganizationId == organizationId) && a.State == StateEnum.active);
            return _mapper.Map<IEnumerable<DimensionTypeResponseDto>>(list);
        }

        public async Task<DimensionType> GetById(long Id)
        {
            return await _unitOfWork.Repository<DimensionType>().Get(Id);
        }
    }
}
