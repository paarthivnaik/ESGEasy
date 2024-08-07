using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.UnitOfMeasureRepo
{
    public class UnitOfMeasureTypeRepo : GenericRepository<UnitOfMeasureType>, IUnitOfMeasureType
    {
        public readonly ApplicationDbContext _applicationDb;
        public UnitOfMeasureTypeRepo(ApplicationDbContext context) : base(context)
        {
            _applicationDb = context;
        }
    }
}
