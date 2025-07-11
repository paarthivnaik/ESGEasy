﻿using ESG.Application.Common.Interface.Account;
using ESG.Application.Common.Interface.Currency;
using ESG.Application.Common.Interface.DataModel;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Common.Interface.Dimension;
using ESG.Application.Common.Interface.Dimensions;
using ESG.Application.Common.Interface.DisclosureRequirement;
using ESG.Application.Common.Interface.FileUpload;
using ESG.Application.Common.Interface.Hierarchy;
using ESG.Application.Common.Interface.Language;
using ESG.Application.Common.Interface.Standard;
using ESG.Application.Common.Interface.Topic;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Common.Interface.Value;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface
{
    public interface IUnitOfWork
    {
        IUnitOfMeasureTypeRepo UnitOfMeasureTypeRepo { get; }
        IUnitOfMeasureRepo UnitOfMeasure { get; }
        IDimensionRepo DimensionRepo { get; }
        IDimensionTypeRepo DimensionTypeRepo { get; }
        IDisclosureRequirementRepo DisclosureRequirementRepo { get; }
        ICurrencyRepo CurrencyRepo { get; }
        IValuesRepo ValuesRepo { get; }
        IHierarchyRepo HierarchyRepo { get; }
        IDataModelRepo DataModelRepo { get; }
        ILanguageRepo LanguageRepo { get; }
        ITopicRepo TopicRepo { get; }
        IStandardRepo StandardRepo { get; }
        IDatapointValueRepo DatapointValueRepo { get; }
        IUsersRepo UsersRepo { get; }
        IOrganizationRepo OrganizationRepo { get; }
        Task<int> SaveAsync();
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
