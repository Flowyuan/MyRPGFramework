using System.Collections.Generic;
using Core.Components;
using Core.Entities;

namespace Core
{
    public static class EntityUtil
    {
        public static Dictionary<Entity, T> ToComponentDictionary<T>(this List<Entity> list) where T:RComponent
        {
            Dictionary<Entity, T> dictionary = new();
            foreach (var entity in list)
            {
                T component = entity.ObtainComponent<T>();
                if (component!=null)
                {
                    dictionary.Add(entity, component);
                }
            }

            return dictionary;
        }
    }
}