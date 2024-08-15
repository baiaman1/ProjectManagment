using System;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Models;

public partial class Document
{
    public int DocumentId { get; set; }

    public int ProjectId { get; set; }

    public string DocumentName { get; set; } = null!;

    public byte[] DocumentData { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
