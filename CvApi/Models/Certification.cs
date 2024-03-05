using System;
using System.Collections.Generic;

namespace CvApi.Models;

public partial class Certification
{
    public int Id { get; set; }

    public string CertificationName { get; set; } = null!;

    public string IssuedBy { get; set; } = null!;

    public DateOnly EarnedDate { get; set; }

    public string? CredentialId { get; set; }

    public string? CredentialLink { get; set; }

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
