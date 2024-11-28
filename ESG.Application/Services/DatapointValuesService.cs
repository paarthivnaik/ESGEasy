using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Dto.DatapointValue;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using ESG.Domain.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DataPointValueService : IDataPointValueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatapointValueRepo _datapointValueRepo;

        private readonly IMapper _mapper;
        public DataPointValueService(IUnitOfWork unitOfWork, IDatapointValueRepo datapointValueRepo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _datapointValueRepo = datapointValueRepo;
            _mapper = mapper;
        }

        public async Task AddAsync(List<DatapointValueCreateRequestDto> DataPointValue)
        {
            var oldDatapoints = new List<DataPointValue>();
            var newDatapoints = new List<DataPointValue>();
            var oldDatapointTranslations = new List<DatapointValueTranslation>();
            var newDatapointTranslations = new List<DatapointValueTranslation>();
            if (DataPointValue != null)
            {
                foreach (var datapoint in DataPointValue)
                {
                    if (DataPointValue != null && datapoint.DatapointId > 0)
                    {
                        var iflinkeddatamodel = await _unitOfWork.DataModelRepo.GetDatamodelLinkedToDatapointByIdAndOrganizationId(datapoint.DatapointId, datapoint.OrganizationId);
                        if (iflinkeddatamodel != null)
                        {
                            throw new System.Exception($"Id with {datapoint.DatapointId} is alredy linked to a datamodel so you cannot modify this datapoint ");
                        }
                        var existingdatapoint = await _unitOfWork.Repository<DataPointValue>().Get(a => a.Id == datapoint.DatapointId);
                        var existingTranslation = await _unitOfWork.Repository<DatapointValueTranslation>().Get(a => a.DatapointValueId == datapoint.DatapointId);
                        existingdatapoint.DatapointTypeId = datapoint.DatapointTypeId;
                        existingdatapoint.UnitOfMeasureId = datapoint.UnitOfMeasureId;
                        existingdatapoint.CurrencyId = datapoint.CurrencyId;
                        existingdatapoint.IsNarrative = datapoint.IsNarrative;
                        existingdatapoint.LanguageId = datapoint.LanguageId;
                        existingdatapoint.LastModifiedBy = datapoint.UserId;
                        existingdatapoint.LastModifiedDate = DateTime.UtcNow;
                        existingdatapoint.Purpose = datapoint.Purpose;
                        existingdatapoint.ShortText = datapoint.ShortText;
                        existingdatapoint.LongText = datapoint.LongText;
                        existingdatapoint.DisclosureRequirementId = datapoint.DisclosureRequirementId;

                        existingTranslation.LanguageId = datapoint.LanguageId;
                        existingTranslation.DatapointValueId = datapoint.DatapointId;
                        existingTranslation.Purpose = datapoint.Purpose;
                        existingTranslation.ShortText = datapoint.ShortText;
                        existingTranslation.LongText = datapoint.LongText;
                        existingTranslation.LanguageId = datapoint.LanguageId;
                        existingTranslation.LastModifiedBy = datapoint.UserId;
                        existingTranslation.LastModifiedDate = DateTime.UtcNow;
                        oldDatapoints.Add(existingdatapoint);
                        oldDatapointTranslations.Add(existingTranslation);
                    }
                    else
                    {
                        var code = datapoint.Code.ToLower();
                        var existingdatapointCode = await _unitOfWork.Repository<DataPointValue>().Get(a => a.Code == code && a.State == Domain.Enum.StateEnum.active);
                        if (existingdatapointCode != null)
                        {
                            throw new System.Exception($"The Datapoint with code - {datapoint.Code} already exists");
                        }
                        var newDP = _mapper.Map<DataPointValue>(datapoint);
                        newDP.Code = code;
                        newDP.State = Domain.Enum.StateEnum.active;
                        newDatapoints.Add(newDP);
                        var newDPTranslation = new DatapointValueTranslation();
                        newDPTranslation.LanguageId = datapoint.LanguageId;
                        newDPTranslation.DatapointValueId = newDP.Id;
                        newDPTranslation.Purpose = datapoint.Purpose;
                        newDPTranslation.ShortText = datapoint.ShortText;
                        newDPTranslation.LongText = datapoint.LongText;
                        newDPTranslation.LanguageId = datapoint.LanguageId;
                        newDPTranslation.CreatedBy = datapoint.UserId;
                        newDPTranslation.CreatedDate = DateTime.UtcNow;
                        newDP.DatapointValueTranslations = new List<DatapointValueTranslation>() { newDPTranslation};
                        newDatapointTranslations.Add(newDPTranslation);
                    }
                }
            }
            await _unitOfWork.Repository<DataPointValue>().UpdateRange(oldDatapoints);
            await _unitOfWork.Repository<DatapointValueTranslation>().UpdateRange(oldDatapointTranslations);
            await _unitOfWork.Repository<DataPointValue>().AddRangeAsync(newDatapoints);
            await _unitOfWork.Repository<DatapointValueTranslation>().AddRangeAsync(newDatapointTranslations);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDatapoint(DatapointValueDeleteRequestDto datapointValueDeleteRequestDto)
        {
            var dataPoint = await _unitOfWork.Repository<DataPointValue>().Get(uom => uom.Id == datapointValueDeleteRequestDto.DatapointId);
            if (dataPoint == null)
            {
                throw new KeyNotFoundException($"Datapoint with ID {dataPoint.Id} not found.");
            }
            dataPoint.State = datapointValueDeleteRequestDto.State;
            await _unitOfWork.Repository<DataPointValue>().Update(dataPoint);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DataPointValueResponseDto>> GetAll(long organizationId)
        {
            var datapoints = await _unitOfWork.DatapointValueRepo.GetAllDatapointValues(organizationId);
            var list = _mapper.Map<IEnumerable<DataPointValueResponseDto>>(datapoints);
            return list;
        }

        public async Task<DataPointValue> GetById(long Id)
        {
            return await _unitOfWork.Repository<DataPointValue>().Get(Id);
        }


        public async Task<DataPointValue> UpdateAsync(DataPointValue DataPointValue)
        {
            var res = await _unitOfWork.Repository<DataPointValue>().Update(DataPointValue);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

