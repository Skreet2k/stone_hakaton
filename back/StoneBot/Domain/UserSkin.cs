namespace StoneBot.Domain;

public class UserSkin
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long SkinId { get; set; }
    public Skin Skin { get; set; }

    public bool IsActive { get; set; }
}