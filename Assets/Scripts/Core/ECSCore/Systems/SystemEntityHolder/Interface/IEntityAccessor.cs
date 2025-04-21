using System.Collections;
using System.Collections.Generic;
using Core.ECSCore.Entities;

namespace Core.ECSCore
{
    public interface IEntityAccessor:IEnumerable<Entity>
    {
        bool Contains(Entity entity);
    }
}