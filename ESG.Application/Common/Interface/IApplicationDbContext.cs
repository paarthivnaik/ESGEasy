using Microsoft.EntityFrameworkCore;

namespace ESG.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        //DbSet<ESG.Domain.Entities.UnitOfMeasure> UnitOfMeasures { get; set; }
        //DbSet<UnitOfMeasureType> UnitOfMeasureTypes { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
