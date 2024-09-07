using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Currency
{
    public class CurrencyResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string? ShortText { get; set; }
        public string LongText { get; set; }
    }
}
