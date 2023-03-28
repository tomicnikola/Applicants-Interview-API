using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Process
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int RecruiterId { get; set; }

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();

    public virtual ICollection<ProcessStep> ProcessSteps { get; } = new List<ProcessStep>();

    public virtual Recruiter Recruiter { get; set; } = null!;
}
