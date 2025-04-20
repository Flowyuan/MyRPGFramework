using System.Collections;
using System.Collections.Generic;
using Core.ECSCore.Entities;

namespace Core.ECSCore.Systems
{
    public interface IEntityAccessor:IEnumerable<Entity>
    {
        bool Contains(Entity entity);
    }
}