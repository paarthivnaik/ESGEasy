using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DatapointType;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DataPointTypeService : IDatapointTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataPointTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(List<DatapointTypeCreateRequestDto> DataPointType)
        {
            var oldDataPointType = new List<DataPointType>();
            var newDataPointType = new List<DataPointType>();
            if (DataPointType != null)
            {
                foreach (var datapointType in DataPointType)
                {
                    if (datapointType.DatapointTypeId > 0)
                    {
                        var existingDatapointType = await _unitOfWork.Repository<DataPointType>().Get(a => a.Id == datapointType.DatapointTypeId);
                        existingDatapointType.Name = datapointType.Name;
                        existingDatapointType.ShortText = datapointType.ShortText;
                        existingDatapointType.LongText = datapointType.LongText;
                        existingDatapointType.OrganizationId = datapointType.OrganizationId;
                        existingDatapointType.LanguageId = datapointType.LanguageId;
                        existingDatapointType.LastModifiedBy = datapointType.UserId;
                        existingDatapointType.LastModifiedDate = DateTime.UtcNow;
                        
                        oldDataPointType.Add(existingDatapointType);
                    }
                    else
                    {
                        var code = datapointType.Code.ToLower();
                        var dpType = new DataPointType
                        {
                            Code = code,
                            Name = datapointType.Name,
                            ShortText = datapointType.ShortText,
                            LongText = datapointType.LongText,
                            OrganizationId = datapointType.OrganizationId,
                            LanguageId = datapointType.LanguageId,
                            CreatedBy = datapointType.UserId,
                            LastModifiedBy = datapointType.UserId,
                            CreatedDate = DateTime.UtcNow,
                            LastModifiedDate = DateTime.UtcNow,
                            State = ESG.Domain.Enum.StateEnum.active
                        };
                        newDataPointType.Add(dpType);
                    }
                }
            }
            await _unitOfWork.Repository<DataPointType>().UpdateRange(oldDataPointType);
            await _unitOfWork.Repository<DataPointType>().AddRange(newDataPointType);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DataPointType>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DataPointType>> GetAll()
        {
            return await _unitOfWork.Repository<DataPointType>().GetAll();
        }

        public async Task<DataPointType> GetById(long Id)
        {
            return await _unitOfWork.Repository<DataPointType>().Get(Id);
        }

        public async Task<DataPointType> UpdateAsync(DataPointType DataPointType)
        {
            var res = await _unitOfWork.Repository<DataPointType>().Update(DataPointType);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

