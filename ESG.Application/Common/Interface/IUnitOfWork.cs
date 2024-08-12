using ESG.Application.Common.Interface.Dimensions;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface
{
    public interface IUnitOfWork
    {
        IUnitOfMeasureRepo UnitOfMeasure { get; }
        IDimensionRepo DimensionRepo { get; }
        Task<int> SaveAsync();
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
