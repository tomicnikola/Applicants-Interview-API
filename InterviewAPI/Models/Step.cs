using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Step
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<ProcessStep> ProcessSteps { get; } = new List<ProcessStep>();
}
