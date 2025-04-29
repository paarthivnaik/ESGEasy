using AutoMapper;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
        public async Task<IEnumerable<DataPointValue>> GetNamesForFilteredIds(IEnumerable<long> filteredIds,long? languageId)
        {
            var names = await _context.DataPointValue
                .Where(dp => filteredIds.Contains(dp.Id))
                .Select(dp => new DataPointValue
                {
                    Id = dp.Id,                    
                    ShortText = dp.DatapointValueTranslations
                    .Where(dt=>dt.LanguageId == languageId)
                    .Select(dt=>dt.ShortText)
                    .FirstOrDefault(),
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
        public async Task<IEnumerable<DataPointValue>> GetAllDatapointValuesTranslations(long? organizationId,long? langId)
        {
            var list = await _context.DataPointValue
                .Where(x => (x.OrganizationId == 1 || x.OrganizationId == organizationId) && x.State == Domain.Enum.StateEnum.active)
                .Select(d => new DataPointValue
                {
                    Id = d.Id,
                    Code = d.Code,                    
                    LanguageId = (long)langId,
                    OrganizationId = d.OrganizationId,
                    State = d.State,
                    ShortText = d.DatapointValueTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault(),
                    LongText = d.DatapointValueTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.LongText)
                    .FirstOrDefault()
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

        public async Task<IEnumerable<DataPointValue>> GetDatapointValueDetailsByIds(IEnumerable<long?> datapointIds,long? languageId)
        {
            var list = await _context.DataPointValue
                .AsNoTracking()
                .Include(a => a.UnitOfMeasure)
                .Include(c => c.Currency)
                .Include(dt=>dt.DatapointValueTranslations)
                .Where(dp => datapointIds.Contains(dp.Id))
                .ToListAsync();
            return list;
        }
        public async Task<DatapointValueTranslation> GetId()
        {
            var rec = await _context.DatapointValueTranslations
                .OrderByDescending(dp => dp.Id)
                .FirstOrDefaultAsync();

            return rec;
        }
    }
}
