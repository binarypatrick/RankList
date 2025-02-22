namespace RankList.Common.Models;

public record Toast(string Text)
{
    public Guid ToastId { get; } = Guid.CreateVersion7();
    public string Text { get; } = Text;
}
