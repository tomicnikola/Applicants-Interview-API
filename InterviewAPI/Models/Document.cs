using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Document1 { get; set; }

    public string? Url { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<ApplicationDocument> ApplicationDocuments { get; } = new List<ApplicationDocument>();
}
