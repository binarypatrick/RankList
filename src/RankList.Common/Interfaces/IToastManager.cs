using RankList.Common.Models;

namespace RankList.Common.Interfaces;

public interface IToastManager
{
    IEnumerable<Toast> GetActive();

    void RemoveToast(Guid toastId);

    void AddToast(ToastLevel level, string text);
}
