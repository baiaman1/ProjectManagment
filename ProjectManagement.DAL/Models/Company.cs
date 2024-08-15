using System;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Project> ProjectClientCompanies { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectContractorCompanies { get; set; } = new List<Project>();
}
