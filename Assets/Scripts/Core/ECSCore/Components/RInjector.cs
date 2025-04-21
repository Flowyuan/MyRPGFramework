using Components;
using Core.ECSCore.Entities;
using UnityEngine;

namespace Core.ECSCore
{
    public abstract class RInjector:MonoBehaviour
    {
        public void InjectToEntity()
        {
            Entity entity = GetComponent<Entity>();
            DoInject(entity);
        }

        protected abstract void DoInject(Entity entity);
    }
}