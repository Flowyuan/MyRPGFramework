using System;
using System.Collections.Generic;

namespace Core.ECSCore
{
    public interface ISystemWithAlphaEntity:ISystem
    {
        List<Type> GetEntityComponentTypes();
        void BeforeInitialize(IEntityAccessor alphaEntities);
    }
}