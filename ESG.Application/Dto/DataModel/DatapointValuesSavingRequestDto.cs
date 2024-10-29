using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataPointValueSavingRequestDto
    {
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public long DatapointId { get; set; }
        public long? CombinationId { get; set; }
        public long? AmendmentId { get; set; }
        public string? AmendmentValue {  get; set; }
        public List<Values> Values { get; set; }
        
    }

    public class Values
    {
        public long DataModelValueId { get; set; }
        public string? Value { get; set; }
        public string? FileName { get; set; }
        public string? FormFile { get; set; }
    }
}
