using System;
using System.Collections.Generic;

namespace Core.ECSCore
{
    public interface ISystemWithGammaEntity:ISystem
    {
        List<Type> GetEntityComponentTypes();
        void BeforeInitialize(IEntityAccessor alphaEntities);
    }
}