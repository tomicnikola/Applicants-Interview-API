using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class ApplicationStatusChange
{
    public int Id { get; set; }

    public DateTime DateChanged { get; set; }

    public int ApplicationStatusId { get; set; }

    public int ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;
}
