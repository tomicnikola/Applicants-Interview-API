using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Applicant
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; } = new List<Application>();
}
