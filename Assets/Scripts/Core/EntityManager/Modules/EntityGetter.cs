using System.Collections.Generic;
using System.Linq;
using Core.Components;
using Core.Entities;

namespace Core
{
    public static partial class EntityManager
    {
        public static class EntityGetter
        {
            public static List<Entity> GetEntitiesWithComponents<T>() where T:RComponent
            {
                return Entities.Where(entity =>
                    entity.HasComponent<T>()
                ).ToList();
            }
        
            public static List<Entity> GetEntitiesWithComponents<T1, T2>() 
                where T1:RComponent
                where T2:RComponent
            {
                return Entities.Where(entity =>
                    entity.HasComponent<T1>() &&
                    entity.HasComponent<T2>()
                ).ToList();
            }
        
            public static List<Entity> GetEntitiesWithComponents<T1, T2, T3>() 
                where T1:RComponent
                where T2:RComponent
                where T3:RComponent
            {
                return Entities.Where(entity =>
                    entity.HasComponent<T1>() &&
                    entity.HasComponent<T2>() &&
                    entity.HasComponent<T3>()
                ).ToList();
            }
        
            public static List<Entity> GetEntitiesWithComponents<T1, T2, T3, T4>() 
                where T1:RComponent
                where T2:RComponent
                where T3:RComponent
                where T4:RComponent
            {
                return Entities.Where(entity =>
                    entity.HasComponent<T1>() &&
                    entity.HasComponent<T2>() &&
                    entity.HasComponent<T3>() &&
                    entity.HasComponent<T4>()
                ).ToList();
            }
        }
    }
}