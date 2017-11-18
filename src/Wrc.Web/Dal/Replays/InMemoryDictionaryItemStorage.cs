using System;
using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain;

namespace Wrc.Web.Dal.Replays
{
    public abstract class InMemoryDictionaryItemStorage<T> : IDictionaryItemStorage<T> where T : IPublicCodeProvider
    {
        private readonly List<T> _items;
        private readonly Dictionary<string, T> _publicCodeMap;
        private readonly Func<string, T> _unknownItemFactory;

        protected InMemoryDictionaryItemStorage(IEnumerable<T> items, Func<string, T> unknownItemFactory)
        {
            _unknownItemFactory = unknownItemFactory;
            _items = items.ToList();
            _publicCodeMap = _items.ToDictionary(i => i.PublicCode);
        }

        public T GetItemOrDefault(string publicCode)
        {
            if (_publicCodeMap.TryGetValue(publicCode, out var item))
                return item;

            return _unknownItemFactory(publicCode);
        }
    }
}