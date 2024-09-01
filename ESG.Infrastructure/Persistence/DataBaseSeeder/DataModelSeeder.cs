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
            //modelBuilder.Entity<ESG.Domain.Entities.DataModel>().HasData(
            //    new Domain.Entities.DataModel { Id = 1, ModelId = 1, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ESG.Domain.Entities.DataModel { Id = 2, ModelId = 2, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ESG.Domain.Entities.DataModel { Id = 3, ModelId = 3, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ESG.Domain.Entities.DataModel { Id = 4, ModelId = 4, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ESG.Domain.Entities.DataModel { Id = 5, ModelId = 5, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ESG.Domain.Entities.DataModel { Id = 6, ModelId = 6, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
            //modelBuilder.Entity<ModelDatapoints>().HasData(
            //    new ModelDatapoints { Id = 1, DataModelId = 1, DatapointValuesId = 10000, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 2, DataModelId = 2, DatapointValuesId = 10049, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 3, DataModelId = 3, DatapointValuesId = 10230, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 4, DataModelId = 4, DatapointValuesId = 10286, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 5, DataModelId = 5, DatapointValuesId = 10401, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { Id = 6, DataModelId = 5, DatapointValuesId = 10402, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            //    );
            //modelBuilder.Entity<ModelDimensionTypes>().HasData(
            //    new ModelDimensionTypes { Id = 1, DataModelId = 1, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 2, DataModelId = 1, DimensionTypeId = 4, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 3, DataModelId = 2, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 4, DataModelId = 2, DimensionTypeId = 4, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 5, DataModelId = 3, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 6, DataModelId = 3, DimensionTypeId = 4, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 7, DataModelId = 4, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 8, DataModelId = 4, DimensionTypeId = 4, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 9, DataModelId = 5, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 10, DataModelId = 5, DimensionTypeId = 4, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 11, DataModelId = 1, DimensionTypeId = 5, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionTypes { Id = 12, DataModelId = 2, DimensionTypeId = 5, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }

            //    );
            //modelBuilder.Entity<ModelDimensionValues>().HasData(
            //    new ModelDimensionValues { Id = 1, DataModelId = 1, DimensionsId = 22, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 2, DataModelId = 1, DimensionsId = 23, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 3, DataModelId = 1, DimensionsId = 21, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 4, DataModelId = 1, DimensionsId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 5, DataModelId = 1, DimensionsId = 2, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 6, DataModelId = 1, DimensionsId = 3, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 7, DataModelId = 2, DimensionsId = 22, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 8, DataModelId = 2, DimensionsId = 23, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 9, DataModelId = 2, DimensionsId = 21, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 10, DataModelId = 2, DimensionsId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 11, DataModelId = 2, DimensionsId = 2, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 12, DataModelId = 2, DimensionsId = 3, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 13, DataModelId = 1, DimensionsId = 4, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDimensionValues { Id = 14, DataModelId = 2, DimensionsId = 5, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            //    );

            //modelBuilder.Entity<ModelConfiguration>().HasData(
            //    new ModelConfiguration { Id = 1, DataModelId = 1, RowId = 1, ColumnId = 4, FilterId = 5, ViewType = ModelViewTypeEnum.Value, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelConfiguration { Id = 1, DataModelId = 2, RowId = 1, ColumnId = 4, FilterId = 5, ViewType = ModelViewTypeEnum.Value, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
        }
    }
}
