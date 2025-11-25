using System;
using System.Collections.Generic;

namespace BadeePlatform.Models;

public partial class GameSession
{
    public Guid GameId { get; set; }

    public Guid LevelId { get; set; }

    public string ChildId { get; set; } = null!;

    public decimal? Score { get; set; }

    public int? TimeTaken { get; set; }

    public string? AttemptData { get; set; }

    public virtual Child Child { get; set; } = null!;

    public virtual GameLevel Level { get; set; } = null!;
}
