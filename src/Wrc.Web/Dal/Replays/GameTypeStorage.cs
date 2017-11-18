using System.Collections.Generic;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Dal.Replays
{
    internal class GameTypeStorage : InMemoryDictionaryItemStorage<IGameType>
    {
        public GameTypeStorage()
            : base(CreateItems(), c => new UnknownGameType(c))
        {
        }

        private static IEnumerable<IGameType> CreateItems()
        {
            yield return new GameType();
        }
    }
}