namespace RankList.Common.Models;

public record Toast(string text, ToastLevel level)
{
    public Guid ToastId { get; } = Guid.CreateVersion7();
    public string Text { get; } = text;
    public string Level { get; } = level.ToString();
}

public enum ToastLevel
{
    Error,
    Warning,
    Info,
}