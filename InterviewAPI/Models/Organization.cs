using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Organization
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
