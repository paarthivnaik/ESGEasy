using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        #region CRUD Operations
        void Add(T entity);
        Task AddAsync(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task<T> UpdateAsync(long Id, T entity);
        Task UpdateFieldsSave(T entity, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> Delete(long Id);
        Task<bool> Delete(T entity);
        Task<bool> Delete(Expression<Func<T,bool>> where);
        Task<T> Get(long Id);
        Task<T> Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll();
        Task<int>Count(Expression<Func<T, bool>> where);
        Task<int> Count();
        #endregion

        #region properties
        IQueryable<T> Table { get; }
        IQueryable<T> AsNoTracking { get;}
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        #endregion
    }
}
