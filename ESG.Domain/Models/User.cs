using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class User
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid SecurityStamp { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public long LanguageId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<DataModelValue> DataModelValueAccountableUsers { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DataModelValue> DataModelValueConsultNavigations { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DataModelValue> DataModelValueInformNavigations { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DataModelValue> DataModelValueResponsibleUsers { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DataPointValue> DataPointValues { get; set; } = new List<DataPointValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValueAccountableUsers { get; set; } = new List<DefaultDataModelValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValueConsultNavigations { get; set; } = new List<DefaultDataModelValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValueInformNavigations { get; set; } = new List<DefaultDataModelValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValueResponsibleUsers { get; set; } = new List<DefaultDataModelValue>();

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; } = new List<OrganizationUser>();

    public virtual ICollection<UploadedFile> UploadedFiles { get; set; } = new List<UploadedFile>();

    public virtual UserRole? UserRole { get; set; }
}
