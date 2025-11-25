using System;
using System.Collections.Generic;

namespace BadeePlatform.Models;

public partial class GameWorld
{
    public Guid WorldId { get; set; }

    public string? WorldName { get; set; }

    public string? WorldDescription { get; set; }

    public string? UnlockRequirement { get; set; }

    public virtual ICollection<GameLevel> GameLevels { get; set; } = new List<GameLevel>();
}
