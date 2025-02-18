using RankList.Common.Models;

namespace RankList.Common.Services;

public class ToastManager
{
    public static ToastManager Instance { get; } = new ToastManager();
    
    private readonly List<Toast> toasts = [];

    private ToastManager() { }
    
    public IEnumerable<Toast> GetActive()
        => toasts.OrderByDescending(x => x.ToastId);
    
    public void RemoveToast(Guid toastId)
        => toasts.RemoveAll(x => x.ToastId == toastId);
    
    public void AddToast(string text)
        => toasts.Add(new Toast(text));
}