using StoneBot.Domain;

namespace StoneBot.Services;

public class ActiveMinerDto
{
    public Miner Miner { get; set; }

    /// <summary>
    ///     Started At. UTC
    /// </summary>
    public DateTime StartedAt { get; set; }

    public int CollectedInMine { get; set; }
}