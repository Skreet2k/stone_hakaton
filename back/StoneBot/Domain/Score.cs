namespace StoneBot.Domain;

public class Score
{
    public long Id { get; set; }

    public long UserId { get; set; }
    public User? User { get; set; }

    public int TodayScore { get; set; }

    /// <summary>
    ///     Total score
    /// </summary>
    public int TotalScore { get; set; }

    /// <summary>
    ///     Total score without purchases
    /// </summary>
    public int CurrentScore { get; set; }
}