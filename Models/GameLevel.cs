using System;
using System.Collections.Generic;

namespace BadeePlatform.Models;

public partial class GameLevel
{
    public Guid LevelId { get; set; }

    public Guid? WorldId { get; set; }

    public string? LevelName { get; set; }

    public int? ChallangeNo { get; set; }

    public int? Points { get; set; }

    public string? Difficulty { get; set; }

    public string? LevelDescription { get; set; }

    public virtual ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();

    public virtual ICollection<IntelligenceProgress> IntelligenceProgresses { get; set; } = new List<IntelligenceProgress>();

    public virtual GameWorld? World { get; set; }
}
