using System.Collections.Generic;
using Wrc.Domain.Models;

namespace Wrc.Domain.Dal.Repositories
{
    public interface IGenericDictionaryItemRepository<TGenericDictionaryItem>
        : IGenericRepository<TGenericDictionaryItem> where TGenericDictionaryItem : GenericDictionaryItem
    {
        TGenericDictionaryItem GetByPublicCode(string publicCode);
        IList<TGenericDictionaryItem> GetActual();
    }
}