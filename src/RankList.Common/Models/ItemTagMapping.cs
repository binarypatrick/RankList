namespace RankList.Common.Models;

public class ItemTagMapping
{
    public Guid ItemTagMappingId { get; set; }
    public Guid ItemId { get; set; }
    public Guid TagId { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    
    public Tag Tag { get; set; }
    public Item Item { get; set; }
}