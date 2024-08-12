
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.UOMTypeTranslations
{
    public class UOMTypeTranslationsUpdateRequestDto
    {
        public long Id { get; set; }
        public long UnitOfMeasureTypeId { get; set; }
        public long LanguageId { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public StateEnum State { get; set; }
    }
}
