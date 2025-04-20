using System.Collections;
using System.Collections.Generic;
using Core.ECSCore.Entities;

namespace Core.ECSCore.Systems
{
    public interface IEntityHolder:IEnumerable<Entity>
    {
        bool Add(Entity entity);
        bool Remove(Entity entity);
        bool Contains(Entity entity);
    }
}