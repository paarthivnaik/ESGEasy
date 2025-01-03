﻿using AutoMapper;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DatapointRepo
{
    public class DatapointValueRepo : GenericRepository<DataPointValue>, IDatapointValueRepo
    {
        private readonly ApplicationDbContext _context;
        public DatapointValueRepo(ApplicationDbContext context): base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<long>> GetModelDatapointsByOrgId(long orgId)
        {
            var list = await _context.DataModels
                .AsNoTracking()
                .Where(x => x.OrganizationId == orgId && x.State == Domain.Enum.StateEnum.active)
                .SelectMany(a => a.ModelDatapoints.Select(md => md.DatapointValuesId))
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<long?>> GetDataModelValuesDatapointsAndNotUserAssignedByOrgId(long orgId)
        {
            var list = await _context.DataModelValues
                .AsNoTracking()
                .Where(x => x.DataModel.OrganizationId == orgId 
                    && x.DataModel.IsDefaultModel == true
                    && x.Value != null)
                .Select(g => g.DataPointValuesId)
                .Distinct()
                .ToListAsync();

            return list;
        }

        public async Task<IEnumerable<long>> GetModelDatapointsLinkedToDataModels(long orgId)
        {
            var list = await _context.DataModels
                .AsNoTracking()
                .Where(x => x.OrganizationId == orgId && x.IsDefaultModel == false)
                .SelectMany(a => a.ModelDatapoints.Select(md => md.DatapointValuesId))
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<DataPointValue>> GetNamesForFilteredIds(IEnumerable<long> filteredIds)
        {
            var names = await _context.DataPointValue
                .Where(dp => filteredIds.Contains(dp.Id))
                .Select(dp => new DataPointValue
                {
                    Id = dp.Id,
                    ShortText = dp.ShortText,
                    IsNarrative = dp.IsNarrative,
                    DisclosureRequirementId = dp.DisclosureRequirementId
                })
                .ToListAsync();
            return names;
        }
        public async Task<IEnumerable<DataPointValue>> GetAllDatapointValues(long organizationId)
        {
            var list = await _context.DataPointValue
                .AsNoTracking()
                .Where(x => (x.OrganizationId == 1 || x.OrganizationId == organizationId) && x.State == Domain.Enum.StateEnum.active)
                .Select(a => new DataPointValue
                {
                    Id = a.Id,
                    ShortText = a.ShortText,
                    LongText = a.LongText,
                    Code = a.Code,
                    State = a.State,
                    DatapointTypeId = a.DatapointTypeId,
                    UnitOfMeasureId = a.UnitOfMeasureId,
                    CurrencyId = a.CurrencyId,
                    IsNarrative = a.IsNarrative,
                    Purpose = a.Purpose,
                    LanguageId = a.LanguageId,
                    UserId = a.UserId,
                    DisclosureRequirementId = a.DisclosureRequirementId,
                    OrganizationId = a.OrganizationId,
                })
                .ToListAsync();

            return list;
        }

        public async Task<List<(long Id, string Name, string Code)>?> GetHierarchyDatapointDetailsByOrganizationId(long hierarchyId)
        {
            var list = await _context.Hierarchies
                .AsNoTracking()
                .Where(x => x.HierarchyId == hierarchyId)
                    .Select(md => new
                    {
                        Id = md.DataPointValuesId,
                        Name = md.DataPointValues.ShortText,
                        Code = md.DataPointValues.Code,
                    })
                .ToListAsync();
            return list.Select(x => (x.Id, x.Name, x.Code)).ToList();
        }

        public async Task<IEnumerable<DataPointValue>> GetDatapointValueDetailsByIds(IEnumerable<long?> datapointIds)
        {
            var list = await _context.DataPointValue
                .AsNoTracking()
                .Include(a => a.UnitOfMeasure)
                .Include(c => c.Currency)
                .Where(dp => datapointIds.Contains(dp.Id))
                .ToListAsync();
            return list;
        }
    }
}
