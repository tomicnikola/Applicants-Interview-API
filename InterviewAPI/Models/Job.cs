using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DatePublished { get; set; }

    public DateTime JobStartDate { get; set; }

    public int NoOfVacancies { get; set; }

    public int JobCategoryId { get; set; }

    public int JobPositionId { get; set; }

    public int JobPlatformId { get; set; }

    public int OrganizationsId { get; set; }

    public int ProcessId { get; set; }

    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    public virtual JobCategory JobCategory { get; set; } = null!;

    public virtual JobPlatform JobPlatform { get; set; } = null!;

    public virtual JobPosition JobPosition { get; set; } = null!;

    public virtual Organization Organizations { get; set; } = null!;

    public virtual Process Process { get; set; } = null!;
}
