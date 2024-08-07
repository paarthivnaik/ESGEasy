using ESG.Domain.Common;

namespace ESG.Domain.Entities
{
    public class Tenant:BaseEntity<long>
    {
        public string Name { get; set; }
        public  IEnumerable<Organization> Organizations { get; set; }
    }
}
