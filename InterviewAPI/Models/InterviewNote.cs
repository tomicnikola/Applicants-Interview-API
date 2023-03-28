using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class InterviewNote
{
    public int Id { get; set; }

    public string? Notes { get; set; }

    public int InterviewId { get; set; }

    public int RecruiterId { get; set; }

    public bool? Pass { get; set; }

    public virtual Interview Interview { get; set; } = null!;

    public virtual Recruiter Recruiter { get; set; } = null!;
}
