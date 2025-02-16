namespace RankList.Common.Models;

public class User
{
    public Guid UserId { get; set; }
    public required string Username { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    
    
    public IEnumerable<Item> Items { get; set; } = new List<Item>();
    public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
}