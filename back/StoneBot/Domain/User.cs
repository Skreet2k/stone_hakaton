namespace StoneBot.Domain;

public class User
{
    public long Id { get; set; }

    public Score Score { get; set; }

    public List<UserSkin> Skins { get; set; } = new();
    public List<UserBackground> Backgrounds { get; set; } = new();
    public List<UserMiner> Miners { get; set; } = new();
    public List<UserBooster> Boosters { get; set; } = new();
}