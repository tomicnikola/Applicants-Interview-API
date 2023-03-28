using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Application
{
    public int Id { get; set; }

    public DateTime DateOfApplication { get; set; }

    public string Education { get; set; } = null!;

    public string Experience { get; set; } = null!;

    public string OtherInfo { get; set; } = null!;

    public int JobsId { get; set; }

    public int ApplicantId { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual ICollection<ApplicantEvaluation> ApplicantEvaluations { get; } = new List<ApplicantEvaluation>();

    public virtual ICollection<ApplicationDocument> ApplicationDocuments { get; } = new List<ApplicationDocument>();

    public virtual ICollection<ApplicationStatusChange> ApplicationStatusChanges { get; } = new List<ApplicationStatusChange>();

    public virtual ICollection<ApplicationTest> ApplicationTests { get; } = new List<ApplicationTest>();

    public virtual ICollection<Interview> Interviews { get; } = new List<Interview>();

    public virtual Job Jobs { get; set; } = null!;
}
