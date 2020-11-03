using System.Collections.Generic;
using System.Linq;

namespace ManyToManyCore
{
    public static class EntidadIntermediaExtension
    {
        public static ICollection<TDependent> ToDependent<TDependent, THolder, TIdDep, TIdHold>
            (this ICollection<EntidadIntermedia<TDependent, THolder, TIdDep, TIdHold>> collection)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            return collection.Select(i => i.Dependent).ToList();
        }

        public static void AddIntermediate<TDependent, THolder, TIdDep, TIdHold>
            (this ICollection<EntidadIntermedia<TDependent, THolder, TIdDep, TIdHold>> collection, TDependent newItem, THolder holder)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            collection.Add(new EntidadIntermedia<TDependent, THolder, TIdDep, TIdHold>(newItem, holder));
        }
    }
}