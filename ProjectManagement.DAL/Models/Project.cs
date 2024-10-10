using System;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int Priority { get; set; }

    public int? ClientCompanyId { get; set; }

    public int? ContractorCompanyId { get; set; }

    public int? ProjectLeaderId { get; set; }

    public virtual Company? ClientCompany { get; set; }

    public virtual Company? ContractorCompany { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();

    public virtual Employee? ProjectLeader { get; set; }
}
