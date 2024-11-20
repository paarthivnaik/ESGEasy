using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Organization
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string RegistrationId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LatsName { get; set; }

    public string? StreetAddress { get; set; }

    public string? StreetNumber { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Email { get; set; }

    public string? LogoUrl { get; set; }

    public long TenantId { get; set; }

    public long LanguageId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<Amendment> Amendments { get; set; } = new List<Amendment>();

    public virtual ICollection<DataModel> DataModels { get; set; } = new List<DataModel>();

    public virtual ICollection<DataPointType> DataPointTypes { get; set; } = new List<DataPointType>();

    public virtual ICollection<DataPointValue> DataPointValues { get; set; } = new List<DataPointValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValues { get; set; } = new List<DefaultDataModelValue>();

    public virtual ICollection<DimensionType> DimensionTypes { get; set; } = new List<DimensionType>();

    public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual OrganizationHeirarchy? OrganizationHeirarchy { get; set; }

    public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; } = new List<OrganizationUser>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<UnitOfMeasureType> UnitOfMeasureTypes { get; set; } = new List<UnitOfMeasureType>();

    public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; set; } = new List<UnitOfMeasure>();
}
