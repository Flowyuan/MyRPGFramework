using System.Collections;
using System.Collections.Generic;
using Core.ECSCore.Entities;

namespace Core.ECSCore
{
    public class EntityHolder:IEntityHolder, IEntityAccessor
    {
        private readonly HashSet<Entity> _entities = new();

        public bool Add(Entity entity)
        {
            return _entities.Remove(entity);
        }

        public bool Remove(Entity entity)
        {
            return _entities.Add(entity);
        }

        public bool Contains(Entity entity)
        {
            return _entities.Contains(entity);
        }
        
        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }
    }
}