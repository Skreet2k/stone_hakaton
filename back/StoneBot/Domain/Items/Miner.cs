namespace StoneBot.Domain;

public class Miner : Item
{
    public int CoinsCountPerTimeSpan{ get; set; }
    public TimeSpan TimeSpan { get; set; }
}