using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.Hierarchy;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto.Hierarchy;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.HierarchyRepo
{
    public class HierarchyRepo : GenericRepository<UnitOfMeasure>, IHierarchyRepo
    {
        private readonly ApplicationDbContext _context;
        public HierarchyRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> GetNextHierarchyIdAsync()
        {
            var maxHierarchyId = await _context.Hierarchies
                .AsNoTracking()
                .Select(a => (long?)a.HierarchyId) 
                .MaxAsync();
            return maxHierarchyId.HasValue ? maxHierarchyId.Value + 1 : 1; 
        }
        public async Task<long> GetHierarchyIdByOrgId(long organizationId)
        {
            
            var hierarchyId = await _context.OrganizationHeirarchies
                .AsNoTracking()
                .Where(t => t.OrganizationId == organizationId)
                .Select(a => a.HierarchyId)
                .FirstOrDefaultAsync();
             return hierarchyId;
            
        }
        public async Task<List<long>> GetDatapointsByHierarchyId(long? hierarchyId)
        {
            var datapointIds = await _context.Hierarchies
                    .AsNoTracking()
                    .Where(t => t.HierarchyId == hierarchyId)
                    .Select(dp => dp.DataPointValuesId) 
                    .ToListAsync();

            return datapointIds;
        }
        public async Task<List<long>> GetDatapointsLinkedToModelByOrganizationId(long? organizationId)
        {
            var datapointIds = await _context.DataModels
                .AsNoTracking()
                .Where(t => t.OrganizationId == organizationId && t.IsDefaultModel == false)
                .SelectMany(t => t.ModelDatapoints) 
                .Select(mdp => mdp.DatapointValuesId) 
                .ToListAsync();

            return datapointIds;
        }

        public async Task<IEnumerable<DataPointValue>> GetDatapoints(long? disReqId, long? organizationId)
        {
            var datapoints = await _context.DataPointValue
                .AsNoTracking()
                .Where(t => (t.OrganizationId == organizationId || t.OrganizationId == 1) && t.DisclosureRequirementId == disReqId && t.State == Domain.Enum.StateEnum.active)
                .ToListAsync();
            return datapoints;
        }

        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirements(long? standarddId)
        {
            var disreq = await _context.DisclosureRequirements
                .AsNoTracking()
                .Where(t => t.StandardId == standarddId)
                .ToListAsync();
            return disreq;
        }

        public async Task<IEnumerable<Standard>> GetStandards(long? topicId)
        {
            var standard = await _context.Standards
                .AsNoTracking()
                .Where(t => t.TopicId == topicId)
                .ToListAsync();
            return standard;
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            var topic = await _context.Topics
                .AsNoTracking()
                .ToListAsync();
            return topic;
        }

        public async Task<IEnumerable<Hierarchy>> GetHierarchyById(long? hierarchyId)
        {
            var hierarchies = await _context.Hierarchies
                .AsNoTracking()
                .Where(a => a.HierarchyId == hierarchyId)
                .ToListAsync();
            return hierarchies;
        }

        public async Task<long> GetHierarchyIdByUserIdOrgId(long userId, long orgId)
        {
            var hierarchyId = await _context.OrganizationHeirarchies
                .AsNoTracking()
                .Where(a => a.CreatedBy == userId && a.OrganizationId == orgId)
                .Select(a => a.HierarchyId)
                .FirstOrDefaultAsync();
            return hierarchyId;
        }

        public async Task<IEnumerable<Hierarchy>> GetHierarchies(long hierarchyId)
        {
            var hierarchies = await _context.Hierarchies
                .AsNoTracking()
                .Where(a => a.HierarchyId == hierarchyId)
                .ToListAsync();
            return hierarchies;
        }
        public async Task<IEnumerable<long>> GetRemainingDatapointsByOrganizationId(long organizationId)
        {
            var remainingDatapoints = new List<long>();
                //= await _context.Hierarchies
                //.AsNoTracking()
                //.Where(h => h.HierarchyId == _context.OrganizationHeirarchies
                //    .Where(oh => oh.OrganizationId == organizationId)
                //    .Select(oh => oh.HierarchyId)
                //    .FirstOrDefault())
                //.Select(h => h.DataPointValuesId)
                //.Except(
                //    _context.DataModels
                //        .Where(dm => dm.OrganizationId == organizationId && dm.IsDefaultModel == false)
                //        .SelectMany(dm => dm.ModelDatapoints)
                //        .Select(mdp => mdp.DatapointValuesId)
                //)
                //.ToListAsync();
            var hierarchyId = await _context.OrganizationHeirarchies
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId)
                .Select(a => a.HierarchyId)
                .FirstOrDefaultAsync();
            var datapoints = await _context.Hierarchies
                .AsNoTracking()
                .Where(a => a.HierarchyId == hierarchyId)
                .Select(a => a.DataPointValuesId)
                .ToListAsync();
            var modelDatapoints = await _context.DataModels
                        .Where(dm => dm.OrganizationId == organizationId && dm.IsDefaultModel == false)
                        .SelectMany(dm => dm.ModelDatapoints)
                        .Select(mdp => mdp.DatapointValuesId).ToListAsync();
            remainingDatapoints = datapoints.Except(modelDatapoints).ToList();
            return remainingDatapoints;
        }
        public async Task<List<DataModelValue>> GenerateDataModelValues(List<long>? datapoints, long organizationId, long userId)
        {
            var defaultDatamodelValues = new List<DataModelValue>();

            var defaultDatamodel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId && a.IsDefaultModel == true)
                .Include(b => b.ModelDimensionTypes)
                .Include(a => a.ModelConfigurations)
                .Include(a => a.ModelFilterCombinations)
                .FirstOrDefaultAsync();
            if (defaultDatamodel != null && defaultDatamodel.Id > 0)
            {
                var factconfigId = defaultDatamodel.ModelConfigurations.Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Fact).FirstOrDefault();
                var narrativeconfigId = defaultDatamodel.ModelConfigurations.Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Narrative).FirstOrDefault();
                var factrowdimtypeId = factconfigId.RowId;
                var modeldimensiontypeIdforFactRow = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == factconfigId.RowId).FirstOrDefault();
                var modeldimensiontypeIdforFactColumn = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == factconfigId.ColumnId).FirstOrDefault();
                var modeldimensiontypeIdforNarrativeRow = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == narrativeconfigId.RowId).FirstOrDefault();
                var factrowDimensions = await _context.ModelDimensionValues
                    .AsNoTracking()
                    .Where(a => a.ModelDimensionTypesId == modeldimensiontypeIdforFactRow.Id && a.ModelDimensionTypes.DataModel.Id == defaultDatamodel.Id)
                    .Select(a => a.DimensionsId)
                    .ToListAsync();
                //await _unitOfWork.DataModelRepo.GetModelDimensionValuesByTypeIdAndModelId(modeldimensiontypeIdforFactRow.Id, defaultDatamodel.Id);

                var factcoldimensions = await _context.ModelDimensionValues
                    .AsNoTracking()
                    .Where(a => a.ModelDimensionTypesId == modeldimensiontypeIdforFactColumn.Id && a.ModelDimensionTypes.DataModel.Id == defaultDatamodel.Id)
                    .Select(a => a.DimensionsId)
                    .ToListAsync();
                //await _unitOfWork.DataModelRepo.GetModelDimensionValuesByTypeIdAndModelId(modeldimensiontypeIdforFactColumn.Id, defaultDatamodel.Id);

                var narrativerowDimensions = await _context.ModelDimensionValues
                    .AsNoTracking()
                    .Where(a => a.ModelDimensionTypesId == modeldimensiontypeIdforNarrativeRow.Id && a.ModelDimensionTypes.DataModel.Id == defaultDatamodel.Id)
                    .Select(a => a.DimensionsId)
                    .ToListAsync();
                //await _unitOfWork.DataModelRepo.GetModelDimensionValuesByTypeIdAndModelId(modeldimensiontypeIdforNarrativeRow.Id, defaultDatamodel.Id);

                var factfiltercombinations = defaultDatamodel.ModelFilterCombinations
                    .Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Fact)
                    .Select(a => (long?)a.Id)
                    .ToList();
                var narrativefiltercombinations = defaultDatamodel.ModelFilterCombinations
                    .Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Narrative)
                    .Select(a => a.Id).ToList();
                //var list = await _context.DataModelValues
                //    .Where(dmv =>
                //        dmv.DataModelId == defaultDatamodel.Id &&
                //        dmv.DataModel.OrganizationId == request.OrganizationId)
                //    .Include(a => a.DataPointValues)
                //    .Include(dim => dim.Row)
                //    .Include(df => df.Combination)
                //    .ThenInclude(mfc => mfc.SampleModelFilterCombinationValues)
                //    .ToListAsync();
                //_unitOfWork.DataModelRepo.GetDataModelValuesByModelIdOrgId(defaultDatamodel.Id, request.OrganizationId);
                //await _unitOfWork.Repository<DataModelValue>().RemoveRangeAsync(list);

                foreach (var dp in datapoints)
                {
                    var viewtype = await _context.DataPointValue
                        .AsNoTracking()
                        .Where(md => md.Id == dp)
                        .Select(md => md.IsNarrative)
                        .FirstOrDefaultAsync();
                    if (viewtype == null)
                        viewtype = false;
                    if (viewtype != null && viewtype == true)
                    {
                        defaultDatamodelValues =
                        (from narrative in narrativefiltercombinations
                         from rowDimension in narrativerowDimensions
                         select new DataModelValue
                         {
                             DataModelId = defaultDatamodel.Id,
                             DataPointValuesId = dp,
                             CreatedBy = userId,
                             LastModifiedBy = userId,
                             CreatedDate = DateTime.UtcNow,
                             LastModifiedDate = DateTime.UtcNow,
                             RowId = rowDimension,
                             ColumnId = null,
                             CombinationId = narrative,
                             State = Domain.Enum.StateEnum.active
                         }).ToList();

                    }
                    if (viewtype != null && viewtype == false && factfiltercombinations.Count() > 0)
                    {
                        defaultDatamodelValues =
                            (from factfilter in factfiltercombinations
                             from rowDimension in factrowDimensions
                             from colDimension in factcoldimensions
                             select new DataModelValue
                             {
                                 DataModelId = defaultDatamodel.Id,
                                 DataPointValuesId = dp,
                                 CreatedBy = userId,
                                 LastModifiedBy = userId,
                                 CreatedDate = DateTime.UtcNow,
                                 LastModifiedDate = DateTime.UtcNow,
                                 RowId = rowDimension,
                                 ColumnId = colDimension,
                                 CombinationId = factfilter,
                                 State = Domain.Enum.StateEnum.active
                             }).ToList();

                    }
                    if (viewtype != null && viewtype == false && factfiltercombinations.Count() <= 0)
                    {
                        defaultDatamodelValues =
                            (from rowdim in factrowDimensions
                             from coldim in factcoldimensions
                             select new DataModelValue
                             {
                                 DataModelId = defaultDatamodel.Id,
                                 DataPointValuesId = dp,
                                 CreatedBy = userId,
                                 LastModifiedBy = userId,
                                 CreatedDate = DateTime.UtcNow,
                                 LastModifiedDate = DateTime.UtcNow,
                                 RowId = rowdim,
                                 ColumnId = coldim,
                                 CombinationId = null,
                                 State = Domain.Enum.StateEnum.active
                             }).ToList();
                    }
                    //return defaultDatamodelValues;
                }
            }
            return defaultDatamodelValues;
        }
    }
}
