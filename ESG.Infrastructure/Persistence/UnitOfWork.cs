using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.DataModel;
using ESG.Application.Common.Interface.Dimensions;
using ESG.Application.Common.Interface.Hierarchy;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Common.Interface.Value;
using ESG.Domain.Entities;
using ESG.Infrastructure.Persistence.DataModel;
using ESG.Infrastructure.Persistence.DimensionRepo;
using ESG.Infrastructure.Persistence.HierarchyRepo;
using ESG.Infrastructure.Persistence.ValueRepo;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        public IUnitOfMeasureRepo UnitOfMeasure { get; private set; }
        public IDimensionRepo DimensionRepo { get; private set; }
        public IValuesRepo ValuesRepo { get; private set; }
        public IHierarchyRepo HierarchyRepo { get; private set; }
        public IDataModelRepo DataModelRepo { get; private set; }

        private readonly ApplicationDbContext _context;
        IDbContextTransaction dbContextTransaction;
        private Hashtable _repositories;
        //public IUnitOfMeasureRepo _unitOfMeasure { get; private set; }
        #endregion
        #region Ctor
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UnitOfMeasure = new ESG.Infrastructure.Persistence.UnitOfMeasureRepo.UnitOfMeasureRepo(_context);
            DimensionRepo = new DimensionsRepo(_context);
            ValuesRepo = new ValuesRepo(_context);
            HierarchyRepo = new ESG.Infrastructure.Persistence.HierarchyRepo.HierarchyRepo(_context);
            DataModelRepo = new DataModelRepo(_context);
        }
        #endregion
       

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void BeginTransaction()
        {
            dbContextTransaction = _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }
        private bool disposed = false;

 

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            _repositories ??= new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
