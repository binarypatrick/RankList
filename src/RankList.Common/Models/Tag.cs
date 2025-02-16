namespace RankList.Common.Models;

public class Tag
{
    public Guid TagId { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    
    
    public IEnumerable<ItemTagMapping> ItemMappings { get; set; } = new List<ItemTagMapping>();
}