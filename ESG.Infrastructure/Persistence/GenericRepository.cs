using ESG.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Properties
        private readonly ApplicationDbContext _context;

        protected DbSet<T> _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion
        #region Ctor

        #endregion

        #region Utility
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                //if after the rollback of changes the context is still not saving,
                //return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }
        #endregion

        #region Repository Methods
        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }
        #region Add
        public virtual void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                Entities.AddRangeAsync(entities);
                await Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddAsync(T entity)
        {
            //_context.Entry(entity).State = EntityState.Added;
            await Entities.AddAsync(entity);
        }
        #endregion

        #region Read
        public virtual async Task<T> Get(long id)
        {
            try
            {
                return await Entities.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<T> Get(Expression<Func<T, bool>> where)
        {
            try
            {
                return await Entities.AsNoTracking().FirstOrDefaultAsync(where);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return Entities.AsNoTracking();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where)
        {
            return Entities.AsNoTracking().Where(where);
        }
        #endregion

        #region Update
        public virtual async Task<T> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                //Entities.Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
               return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public  async  Task UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.UpdateRange(entities);
                await Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> UpdateAsync(long Id, T entity)
        {
            T exist = _context.Set<T>().Find(Id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            return entity;
        }
        #endregion

        #region Delete
        public virtual async Task<bool> Delete(long id)
        {
            try
            {
                var entity = await Entities.FindAsync(id);
                if (entity == null)
                    return false;

                Entities.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<bool> Delete(T entity)
        {
            try
            {
                if (entity == null)
                    return false;

                Entities.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<bool> Delete(Expression<Func<T, bool>> where)
        {
            try
            {
                var entities = Entities.Where(where);
                Entities.RemoveRange(entities);
                return true;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        #endregion

        #region Save
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual void SaveAsync()
        {
            _context.SaveChangesAsync();
        }
        #endregion

        #region Count
        public virtual async Task<int> Count()
        {
            return await Entities.AsNoTracking().CountAsync();

        }
        public virtual async Task<int> Count(Expression<Func<T, bool>> where)
        {
            return await Entities.AsNoTracking().CountAsync(where);

        }
        #endregion
        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> AsNoTracking => Entities.AsNoTracking();
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }
        #endregion


        public async  Task UpdateFieldsSave(T entity, params Expression<Func<T, object>>[] includeProperties)
        {
            var dbEntry = _context.Entry(entity);
            foreach (var includeProperty in includeProperties)
            {
                dbEntry.Property(includeProperty).IsModified = false;
            }
            await Task.CompletedTask;
        }
    }
}

