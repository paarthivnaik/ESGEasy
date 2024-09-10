using AutoMapper;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DatapointRepo
{
    public class DatapointValueRepo : GenericRepository<DataPointValues>, IDatapointValueRepo
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
                .Where(x => x.OrganizationId == orgId)
                .SelectMany(a => a.ModelDatapoints.Select(md => md.DataPointValues.Id))
                .ToListAsync();

            return list;
        }
        public async Task<IEnumerable<DataPointValues>> GetNamesForFilteredIds(IEnumerable<long> filteredIds)
        {
            var names = await _context.DataPointValues
                .Where(dp => filteredIds.Contains(dp.Id))
                .Select(dp => new DataPointValues
                {
                    Id = dp.Id,
                    Name = dp.Name
                })
                .ToListAsync();
            return names;
        }


    }
}
