namespace StoneBot.Contracts;

public class InitUserRequest
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}