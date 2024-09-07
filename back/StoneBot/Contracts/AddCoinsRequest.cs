namespace StoneBot.Contracts;

public class AddCoinsRequest
{
    public long UserId { get; set; }
    public int Count { get; set; }
}