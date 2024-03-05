using System;
using System.Collections.Generic;

namespace CvApi.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string Workplace { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string Role { get; set; } = null!;

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
