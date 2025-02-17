namespace RankList.Common.Models;

public class Review
{
    public Guid ReviewId { get; set; }
    public Guid ItemId { get; set; }
    public string? Notes { get; set; }
    public float Rating { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;


    public Item Item { get; set; }
    public User Creator { get; set; }
}