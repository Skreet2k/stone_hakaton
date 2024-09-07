namespace StoneBot.Domain;

public class UserBackground
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long BackgroundId { get; set; }
    public Background Background { get; set; }

    public bool IsActive { get; set; }
}