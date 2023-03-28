using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Answer
{
    public int Id { get; set; }

    public int ApplicationTestId { get; set; }

    public int RecruiterId { get; set; }

    public string? TotalGrades { get; set; }

    public bool? Pass { get; set; }

    public string? AnswerDetails { get; set; }

    public virtual ApplicationTest ApplicationTest { get; set; } = null!;

    public virtual Recruiter Recruiter { get; set; } = null!;
}
