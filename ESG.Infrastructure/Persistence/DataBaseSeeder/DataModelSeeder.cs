﻿using ESG.Domain.Models;
using ESG.Domain.Enum;
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
            modelBuilder.Entity<Domain.Models.DataModel>().HasData(
                new Domain.Models.DataModel { Id = 1, ModelName = "Default Model",Purpose = "This Model is default model",IsDefaultModel = true, State = StateEnum.active, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
            //modelBuilder.Entity<ModelDatapoints>().HasData(
            //    new ModelDatapoints { DatapointId = 1, DataModelId = 1, DataPointValueId = 10032, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { DatapointId = 2, DataModelId = 1, DataPointValueId = 10033, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
            //    new ModelDatapoints { DatapointId = 3, DataModelId = 1, DataPointValueId = 10034, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            //    );
            modelBuilder.Entity<ModelDimensionType>().HasData(
                new ModelDimensionType { Id = 1, DataModelId = 1, DimensionTypeId = 1, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionType { Id = 2, DataModelId = 1, DimensionTypeId = 5, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
                 );
            modelBuilder.Entity<ModelDimensionValue>().HasData(
                new ModelDimensionValue { Id = 1, ModelDimensionTypesId = 1, DimensionsId = 1010, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValue { Id = 2, ModelDimensionTypesId = 1, DimensionsId = 1011, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValue { Id = 3, ModelDimensionTypesId = 1, DimensionsId = 1012, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValue { Id = 4, ModelDimensionTypesId = 2, DimensionsId = 1000, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValue { Id = 5, ModelDimensionTypesId = 2, DimensionsId = 1001, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelDimensionValue { Id = 6, ModelDimensionTypesId = 2, DimensionsId = 1002, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
                );

            modelBuilder.Entity<ModelConfiguration>().HasData(
                new ModelConfiguration { Id = 10000, DataModelId = 1, RowId = 1, ColumnId = 5, ViewType = ModelViewTypeEnum.Fact, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new ModelConfiguration { Id = 10001, DataModelId = 1, RowId = 1, ColumnId = null, ViewType = ModelViewTypeEnum.Narrative, State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
            modelBuilder.Entity<DataModelFilter>().HasData(
                new DataModelFilter { Id = 1000, ModelConfigurationId = 10001, FilterId = 5 }
                );

        }
    }
}
