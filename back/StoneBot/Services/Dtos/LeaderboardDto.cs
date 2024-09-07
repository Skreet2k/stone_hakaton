namespace StoneBot.Services;

public class LeaderboardDto
{
    public LeaderDto CurrentUser { get; set; }
    public List<LeaderDto> Leaders { get; set; }
}