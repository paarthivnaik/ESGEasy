using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Dimensions
{
    public class DimensionsResponseDto
    {
        public long Id {  get; set; }
        public string Code { get; set; }
        public StateEnum State { get; set; }
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long UserId { get; set; }
        public string LanguageId { get; set; }
    }
}
