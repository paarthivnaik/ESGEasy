using ESG.Application.Common.Interface.UnitOfMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.UnitOfMeasureRepo
{
    public class UnitOfMeasure : GenericRepository<ESG.Domain.Entities.UnitOfMeasure>, IUnitOfMeasure
    {
        private readonly ApplicationDbContext _context;
        public UnitOfMeasure(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async void AAA(long id)
        {
           var result = await base.Get(id);
        }

    }
}
