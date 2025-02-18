namespace RankList.Common.Models;

public record Toast(string text)
{
    public Guid ToastId { get; } = Guid.CreateVersion7();
    public string Text { get; } = text;
}
