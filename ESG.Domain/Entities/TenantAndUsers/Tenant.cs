using ESG.Domain.Common;

namespace ESG.Domain.Entities.TenantAndUsers
{
    public class Tenant : BaseEntity<long>
    {
        public string Name { get; set; }
        public IEnumerable<Organization> Organizations { get; set; } = new List<Organization>();
    }
}
