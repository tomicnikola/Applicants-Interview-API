using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class Interview
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual ICollection<InterviewNote> InterviewNotes { get; } = new List<InterviewNote>();
}
