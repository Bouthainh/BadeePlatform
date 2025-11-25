using System;
using System.Collections.Generic;

namespace BadeePlatform.Models;

public partial class IntelligenceType
{
    public Guid IntelligenceId { get; set; }

    public string? IntelligenceName { get; set; }

    public string? IntelligenceTypeDescription { get; set; }

    public string? IconImgPath { get; set; }

    public virtual ICollection<ChildIntelligence> ChildIntelligences { get; set; } = new List<ChildIntelligence>();

    public virtual ICollection<IntelligenceProgress> IntelligenceProgresses { get; set; } = new List<IntelligenceProgress>();
}
