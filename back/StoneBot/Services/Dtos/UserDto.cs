namespace StoneBot.Services;

public class UserDto
{
    public long Id { get; set; }

    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public long? SkinId { get; set; }

    public string Avatar { get; set; } = "images/avatar.png";
}