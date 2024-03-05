using System;
using System.Collections.Generic;

namespace CvApi.Models;

public partial class Education
{
    public int Id { get; set; }

    public string Institution { get; set; } = null!;

    public DateOnly StartYear { get; set; }

    public DateOnly? EndYear { get; set; }

    public string Degree { get; set; } = null!;

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
