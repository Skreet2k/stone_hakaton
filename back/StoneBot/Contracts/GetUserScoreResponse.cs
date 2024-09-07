namespace StoneBot.Contracts;

public class GetUserScoreResponse
{
    public int TotalScore { get; set; }
    public int TodayScore { get; set; }
    public int TodayLimit { get; set; }
}