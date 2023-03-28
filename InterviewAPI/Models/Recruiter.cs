using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Recruiter
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();

    public virtual ICollection<ApplicantEvaluation> ApplicantEvaluations { get; } = new List<ApplicantEvaluation>();

    public virtual ICollection<InterviewNote> InterviewNotes { get; } = new List<InterviewNote>();

    public virtual ICollection<Process> Processes { get; } = new List<Process>();
}
