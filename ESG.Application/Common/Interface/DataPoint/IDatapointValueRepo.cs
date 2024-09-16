using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.DataPoint
{
    public interface IDatapointValueRepo
    {
        Task<IEnumerable<long>> GetModelDatapointsByOrgId(long orgId);
        Task<IEnumerable<DataPointValues>> GetNamesForFilteredIds(IEnumerable<long> filteredIds);
    }
}
