using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDatapointValuesService
    {
        Task AddAsync(List<DatapointValueCreateRequestDto> datapointValues);
        Task<DataPointValues> UpdateAsync(DataPointValues datapointValues);
        Task<IEnumerable<DatapointValuesResponseDto>> GetAll();
        Task<DatapointsByOrgIdResponseDto> GetDataPointsByOrganizationId(long organizationId);
        Task<DataPointValues> GetById(long Id);
        Task DeleteDatapoint(DatapointDeleteRequestDto deleteRequest);
    }
}
