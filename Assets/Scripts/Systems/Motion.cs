using System;
using System.Collections.Generic;
using Components;
using Components.Enum;
using Core;
using Core.ECSCore;
using UnityEngine;
using static Core.EntityManager;

namespace Systems
{
    public class Motion:ISystem, ISystemWithAlphaEntity
    {
        private IEntityAccessor _alphaEntities;
        
        public List<Type> GetEntityComponentTypes()
        {
            return new List<Type>
            {
                typeof(MotionComponent),
                typeof(TransformComponent)
            };
        }

        public void BeforeInitialize(IEntityAccessor alphaEntities)
        {
            _alphaEntities = alphaEntities;
        }
        

        public void Tick()
        {
            foreach (var entity in _alphaEntities)
            {
                var motionComponent = entity.ObtainComponent<MotionComponent>();
                var transformComponent = entity.ObtainComponent<TransformComponent>();
                switch (motionComponent.MoveType)
                {
                    case MoveType.SimpleMove:
                        ExcuteSimpleMove(transformComponent, motionComponent);
                        break;
                    case MoveType.KeyboardMove:
                        ExcuteKeyboardMove(transformComponent, motionComponent);
                        break;
                }
                
            }
        }

        public void ExcuteSimpleMove(TransformComponent transform, MotionComponent motion)
        {
            motion.Direction = motion.Direction.normalized;
            transform.Translate(motion.Direction * (motion.Speed * Time.deltaTime));
        }

        public void ExcuteKeyboardMove(TransformComponent transform, MotionComponent motion)
        {
            var inputX = Input.GetAxisRaw("Horizontal");
            var inputY = Input.GetAxisRaw("Vertical");
            motion.Direction = new Vector2(inputX, inputY).normalized;
            transform.Translate(motion.Direction * (motion.Speed * Time.deltaTime));
        }
    }
}

