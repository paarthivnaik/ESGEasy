using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DatapointType;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DatapointTypesService : IDatapointTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DatapointTypesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(List<DatapointTypeCreateRequestDto> dataPointTypes)
        {
            var oldDatapointTypes = new List<DataPointTypes>();
            var newDatapointTypes = new List<DataPointTypes>();
            if (dataPointTypes != null)
            {
                foreach (var datapointType in dataPointTypes)
                {
                    if (datapointType.DatapointTypeId > 0)
                    {
                        var existingDatapointType = await _unitOfWork.Repository<DataPointTypes>().Get(a => a.Id == datapointType.DatapointTypeId);
                        existingDatapointType.Name = datapointType.Name;
                        existingDatapointType.ShortText = datapointType.ShortText;
                        existingDatapointType.LongText = datapointType.LongText;
                        existingDatapointType.OrganizationId = datapointType.OrganizationId;
                        existingDatapointType.LanguageId = datapointType.LanguageId;
                        existingDatapointType.LastModifiedBy = datapointType.UserId;
                        existingDatapointType.LastModifiedDate = DateTime.UtcNow;
                        
                        oldDatapointTypes.Add(existingDatapointType);
                    }
                    else
                    {
                        var dpType = new DataPointTypes
                        {
                            Code = datapointType.Code,
                            Name = datapointType.Name,
                            ShortText = datapointType.ShortText,
                            LongText = datapointType.LongText,
                            OrganizationId = datapointType.OrganizationId,
                            LanguageId = datapointType.LanguageId,
                            CreatedBy = datapointType.UserId,
                            LastModifiedBy = datapointType.UserId,
                            CreatedDate = DateTime.UtcNow,
                            LastModifiedDate = DateTime.UtcNow,
                            State = StateEnum.active
                        };
                        newDatapointTypes.Add(dpType);
                    }
                }
            }
            await _unitOfWork.Repository<DataPointTypes>().UpdateRange(oldDatapointTypes);
            await _unitOfWork.Repository<DataPointTypes>().AddRange(newDatapointTypes);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<DataPointTypes>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<DataPointTypes>> GetAll()
        {
            return await _unitOfWork.Repository<DataPointTypes>().GetAll();
        }

        public async Task<DataPointTypes> GetById(long Id)
        {
            return await _unitOfWork.Repository<DataPointTypes>().Get(Id);
        }

        public async Task<DataPointTypes> UpdateAsync(DataPointTypes dataPointTypes)
        {
            var res = await _unitOfWork.Repository<DataPointTypes>().Update(dataPointTypes);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

