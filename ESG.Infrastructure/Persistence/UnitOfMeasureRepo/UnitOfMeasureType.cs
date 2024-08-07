using ESG.Application.Common.Interface.UnitOfMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.UnitOfMeasureRepo
{
    public class UnitOfMeasureType : GenericRepository<UnitOfMeasureType>, IUnitOfMeasureType
    {
        public readonly ApplicationDbContext _applicationDb;
        public UnitOfMeasureType(ApplicationDbContext context) : base(context)
        {
            _applicationDb = context;
        }
    }
}
