using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
