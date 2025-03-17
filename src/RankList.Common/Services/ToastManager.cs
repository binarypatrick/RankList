using RankList.Common.Interfaces;
using RankList.Common.Models;

namespace RankList.Common.Services;

public class ToastManager : IToastManager
{
    private readonly List<Toast> toasts = [];

    public IEnumerable<Toast> GetActive()
        => toasts.OrderByDescending(x => x.ToastId);
    
    public void RemoveToast(Guid toastId)
        => toasts.RemoveAll(x => x.ToastId == toastId);
    
    public void AddToast(ToastLevel level, string text)
        => toasts.Add(new Toast(text, level));
}