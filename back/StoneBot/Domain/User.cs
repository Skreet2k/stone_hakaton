namespace StoneBot.Domain;

public class User
{
    public long Id { get; set; }

    public List<Score> Scores { get; set; } = new();

    public List<Skin> Skins { get; set; } = new();
}

public class Score
{
    public long Id { get; set; }

    public long UserId { get; set; }
    public User? User { get; set; }

    public int Count { get; set; }

    public int MaxCount { get; set; }

    public DateOnly Date { get; set; }
}

public class Skin
{
    public long Id { get; set; }
    public string Slug { get; set; }
}

public class UserSkin
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long SkinId { get; set; }
    public Skin Skin { get; set; }
}