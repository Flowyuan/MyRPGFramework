using System;
using System.Collections.Generic;

namespace Core.ECSCore
{
    public interface ISystemWithDeltaEntity:ISystem
    {
        List<Type> GetEntityComponentTypes();
        void BeforeInitialize(IEntityAccessor alphaEntities);

    }
}