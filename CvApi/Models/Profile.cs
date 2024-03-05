using System;
using System.Collections.Generic;

namespace CvApi.Models;

public partial class Profile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Birth { get; set; }

    public string Location { get; set; } = null!;

    public string[]? Skills { get; set; }

    public string? ProfileText { get; set; }

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<Social> Socials { get; set; } = new List<Social>();

    public virtual ICollection<Strength> Strengths { get; set; } = new List<Strength>();
}
