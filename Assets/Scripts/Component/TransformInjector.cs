using Core.Components;
using Core.Entities;

namespace Components
{
    public class TransformInjector:RInjector
    {
        protected override void DoInject(Entity entity)
        {
            var component = entity.AddComponent<TransformComponent>();
            component.EntityTransform = transform;
        }
    }
}