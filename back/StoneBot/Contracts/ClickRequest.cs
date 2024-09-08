namespace StoneBot.Contracts;

public class ClickRequest
{
    /// <summary>
    ///     User ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///     Clicks Count. By default 1
    /// </summary>
    public int Count { get; set; } = 1;
}