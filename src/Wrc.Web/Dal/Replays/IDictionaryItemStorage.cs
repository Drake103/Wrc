using Wrc.Web.Domain;

namespace Wrc.Web.Dal.Replays
{
    public interface IDictionaryItemStorage<out T> where T : IPublicCodeProvider
    {
        T GetItemOrDefault(string publicCode);
    }
}