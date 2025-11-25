using System;
using System.Collections.Generic;

namespace BadeePlatform.Models;

public partial class IntelligenceProgress
{
    public Guid ProgressId { get; set; }

    public string? ChildId { get; set; }

    public Guid? LevelId { get; set; }

    public Guid? IntelligenceId { get; set; }

    public decimal? Score { get; set; }

    public DateTime? RecordDate { get; set; }

    public virtual Child? Child { get; set; }

    public virtual IntelligenceType? Intelligence { get; set; }

    public virtual GameLevel? Level { get; set; }
}
