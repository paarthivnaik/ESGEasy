﻿using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Models;
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
        Task<IEnumerable<long?>> GetDataModelValuesDatapointsAndNotUserAssignedByOrgId(long orgId);
        Task<IEnumerable<long>> GetModelDatapointsLinkedToDataModels(long orgId);
        Task<IEnumerable<DataPointValue>> GetNamesForFilteredIds(IEnumerable<long> filteredIds);
        Task<IEnumerable<DataPointValue>> GetDatapointValueDetailsByIds(IEnumerable<long?> datapointIds);
        Task<IEnumerable<DataPointValue>> GetAllDatapointValues(long organizationId);
        Task<List<(long Id, string Name, string Code)>?> GetHierarchyDatapointDetailsByOrganizationId(long organizationId);
    }
}
