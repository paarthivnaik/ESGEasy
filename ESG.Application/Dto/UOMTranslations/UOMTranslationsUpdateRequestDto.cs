using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.UOMTranslations
{
    public class UOMTranslationsUpdateRequestDto
    {

        public long Id { get; set; }
        public long UnitOfMeasureId { get; set; }
        public long LanguageId { get; set; }
        public string ShortText {  get; set; }
        public string LongText { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public StateEnum State { get; set; }
    }
}
