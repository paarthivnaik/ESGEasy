using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.UnitOfMeasure
{
    public class UnitOfMeasureDeleteRequest
    {
        public long Id { get; set; }
        public StateEnum State { get; set; }
    }
}
