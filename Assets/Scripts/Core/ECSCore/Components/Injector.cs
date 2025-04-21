using Components;
using UnityEngine;

namespace Core.ECSCore
{
    public abstract class Injector:MonoBehaviour
    {
        public void InjectToEntity()
        {
            Entity entity = GetComponent<Entity>();
            DoInject(entity);
        }

        protected abstract void DoInject(Entity entity);
    }
}