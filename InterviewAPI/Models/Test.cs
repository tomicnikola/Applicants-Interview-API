using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Test
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int? Duration { get; set; }

    public int MaxScore { get; set; }

    public virtual ICollection<ApplicationTest> ApplicationTests { get; } = new List<ApplicationTest>();
}
