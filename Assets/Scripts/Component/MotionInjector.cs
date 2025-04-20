using Components.Enum;
using Core.Components;
using Core.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
    public class MotionInjector:RInjector
    {
        public MoveType MoveType ;
        public float Speed;
        public Vector2 Direction;

        protected override void DoInject(Entity entity)
        {
            var component = entity.AddComponent<MotionComponent>();
            component.MoveType = MoveType;
            component.Speed = Speed;
            component.Direction = Direction;
        }
    }
}