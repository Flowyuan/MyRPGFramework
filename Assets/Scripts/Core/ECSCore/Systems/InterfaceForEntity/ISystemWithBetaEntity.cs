using System;
using System.Collections.Generic;

namespace Core.ECSCore.Systems
{
    public interface ISystemWithBetaEntity:ISystem
    {
        List<Type> GetEntityComponentTypes();
        void BeforeInitialize(IEntityAccessor alphaEntities);
    }
}