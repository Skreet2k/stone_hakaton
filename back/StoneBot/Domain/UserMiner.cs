namespace StoneBot.Domain;

public class UserMiner
{

    public long UserId { get; set; }
    public User User { get; set; }

    public long MinerId { get; set; }
    public Miner Miner { get; set; }

    public bool IsActive { get; set; }
}