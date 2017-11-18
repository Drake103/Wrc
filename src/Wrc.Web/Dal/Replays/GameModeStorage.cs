using System.Collections.Generic;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Dal.Replays
{
    internal class GameModeStorage : InMemoryDictionaryItemStorage<IGameMode>
    {
        public GameModeStorage()
            : base(CreateItems(), c => new UnknownGameMode(c))
        {
        }

        private static IEnumerable<IGameMode> CreateItems()
        {
            yield break;
        }
    }
}