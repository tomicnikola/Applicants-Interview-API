using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class ApplicationTest
{
    public int Id { get; set; }

    public int TestId { get; set; }

    public int ApplicationId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();

    public virtual Application Application { get; set; } = null!;

    public virtual Test Test { get; set; } = null!;
}
