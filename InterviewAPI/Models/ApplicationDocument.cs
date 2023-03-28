using System;
using System.Collections.Generic;

namespace InterviewAPI.Models;

public partial class ApplicationDocument
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;
}
