namespace RankList.Common.Models;

public class Item
{
    public Guid ItemId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public float? AverageRating { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    public User Creator { get; set; }
    public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
    public IEnumerable<ItemTagMapping> TagMappings { get; set; } = new List<ItemTagMapping>();
}