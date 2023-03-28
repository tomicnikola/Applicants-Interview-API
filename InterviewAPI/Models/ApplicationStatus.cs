using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class ApplicationStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<ApplicationStatusChange> ApplicationStatusChanges { get; } = new List<ApplicationStatusChange>();
}
