using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class ProcessStep
{
    public int Id { get; set; }

    public int StepId { get; set; }

    public int ProcessId { get; set; }

    public string? Status { get; set; }

    public int Priority { get; set; }

    public virtual Process Process { get; set; } = null!;

    public virtual Step Step { get; set; } = null!;
}
