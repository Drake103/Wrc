using System.Collections.Generic;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Dal.Replays
{
    public class VictoryConditionStorage : InMemoryDictionaryItemStorage<IVictoryCondition>
    {
        public VictoryConditionStorage()
            : base(CreateItems(), c => new UnknownVictoryCondition(c))
        {
        }

        private static IEnumerable<IVictoryCondition> CreateItems()
        {
            yield return new VictoryCondition();
        }
    }
}