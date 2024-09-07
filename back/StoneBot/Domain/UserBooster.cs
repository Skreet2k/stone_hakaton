namespace StoneBot.Domain;

public class UserBooster
{

    public long UserId { get; set; }
    public User User { get; set; }

    public long BoosterId { get; set; }
    public Booster Booster { get; set; }

    public bool IsActive { get; set; }
}