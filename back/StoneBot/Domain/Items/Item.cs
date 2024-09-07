namespace StoneBot.Domain;

public abstract class Item
{
    public long Id { get; set; }

    /// <summary>
    ///     User friendly name.
    /// </summary>
    /// <remarks> Uses instead ID </remarks>
    public string Slug { get; set; }

    public string Name { get; set; }

    public string Discription { get; set; }

    public string Url { get; set; }

    public int Price { get; set; }
}