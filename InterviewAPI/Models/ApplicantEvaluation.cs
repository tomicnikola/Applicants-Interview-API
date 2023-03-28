using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class ApplicantEvaluation
{
    public int Id { get; set; }

    public string Notes { get; set; } = null!;

    public int RecruiterId { get; set; }

    public int ApplicationId { get; set; }

    public bool? Hired { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual Recruiter Recruiter { get; set; } = null!;
}
