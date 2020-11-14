using System.Collections.Generic;
using System.Linq;

namespace ManyToManyCore
{
    public static class EntidadIntermediaExtension
    {
        /// <summary> 
        /// Returns the holder (right) entities as ICollection
        /// Usually it wo
        /// </summary>
        public static ICollection<THolder> ToEntity1<TDependent, THolder, TIdDep, TIdHold>
            (this ICollection<MiddleEntity<TDependent, THolder, TIdDep, TIdHold>> collection)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            return collection.Select(i => i.Holder).ToList();
        }

        /// <summary> 
        /// Returns the dependent (left) entities as ICollection
        /// </summary>
        public static ICollection<TDependent> ToDependent<TDependent, THolder, TIdDep, TIdHold>
            (this ICollection<MiddleEntity<TDependent, THolder, TIdDep, TIdHold>> collection)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            return collection.Select(i => i.Dependent).ToList();
        }

        /// <summary> 
        /// Adds a new Item to Intermediate entity collection
        /// </summary>
        /// <returns>The new Intermediate element</returns>
        public static MiddleEntity<TDependent, THolder, TIdDep, TIdHold> AddIntermediate<TDependent, THolder, TIdDep, TIdHold>
            (this ICollection<MiddleEntity<TDependent, THolder, TIdDep, TIdHold>> collection, TDependent newItem, THolder holder)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            var entity = new MiddleEntity<TDependent, THolder, TIdDep, TIdHold>(newItem, holder);
            collection.Add(entity);
            return entity;
        }

        /// <summary> 
        /// Adds a new Item to Intermediate entity collection
        /// </summary>
        /// <returns>The new Intermediate element</returns>
        public static MiddleEntity<TDependent, THolder, TIdDep, TIdHold> AddIntermediate<TDependent, THolder, TIdDep, TIdHold>
            (this ICollection<MiddleEntity<TDependent, THolder, TIdDep, TIdHold>> collection, THolder newItem, TDependent dependent)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            var entity = new MiddleEntity<TDependent, THolder, TIdDep, TIdHold>(dependent, newItem);
            collection.Add(entity);
            return entity;
        }
    }
}