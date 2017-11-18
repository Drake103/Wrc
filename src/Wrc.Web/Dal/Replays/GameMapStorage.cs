using System.Collections.Generic;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Dal.Replays
{
    public class GameMapStorage : InMemoryDictionaryItemStorage<IGameMap>
    {
        public GameMapStorage()
            : base(CreateItems(), c => new UnknownGameMap(c))
        {
        }

        private static IEnumerable<IGameMap> CreateItems()
        {
            yield break;
        }
    }
}