using System;
using System.Collections.Generic;

namespace Core.ECSCore.Systems
{
    public interface ISystemWithGammaEntity:ISystem
    {
        List<Type> GetEntityComponentTypes();
        void BeforeInitialize(IEntityAccessor alphaEntities);
    }
}