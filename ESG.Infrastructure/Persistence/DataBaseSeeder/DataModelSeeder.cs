using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public class DataModelSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ESG.Domain.Entities.DataModel>().HasData(
                new Domain.Entities.DataModel { Id = 1, ModelName = "Default Model", State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
            //modelBuilder.Entity<ModelDatapoints>().HasData(
            //    new ModelDatapoints { Id = 1, DataModelId = 1, DatapointValuesId = 10032, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 2, DataModelId = 1, DatapointValuesId = 10033, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 3, DataModelId = 1, DatapointValuesId = 10034, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            //    );
            modelBuilder.Entity<ModelDimensionTypes>().HasData(
                new ModelDimensionTypes { Id = 1, DataModelId = 1, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionTypes { Id = 2, DataModelId = 1, DimensionTypeId = 5, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
                 );
            modelBuilder.Entity<ModelDimensionValues>().HasData(
                new ModelDimensionValues { Id = 1, ModelDimensionTypesId = 1, DimensionsId = 1010, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValues { Id = 2, ModelDimensionTypesId = 1, DimensionsId = 1011, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValues { Id = 3, ModelDimensionTypesId = 1, DimensionsId = 1012, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValues { Id = 4, ModelDimensionTypesId = 2, DimensionsId = 1000, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValues { Id = 5, ModelDimensionTypesId = 2, DimensionsId = 1001, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValues { Id = 6, ModelDimensionTypesId = 2, DimensionsId = 1002, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
                );

            modelBuilder.Entity<ModelConfiguration>().HasData(
                new ModelConfiguration { Id = 10000, DataModelId = 1, RowId = 1, ColumnId = 5, ViewType = ModelViewTypeEnum.Fact, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelConfiguration { Id = 10001, DataModelId = 1, RowId = 1, ColumnId = null, ViewType = ModelViewTypeEnum.Narrative, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
            modelBuilder.Entity<DataModelFilters>().HasData(
                new DataModelFilters { Id = 1000, ModelConfigurationId = 10001, FilterId = 5 }
                );

        }
    }
}
