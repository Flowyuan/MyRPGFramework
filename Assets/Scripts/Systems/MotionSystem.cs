using System.Collections.Generic;
using Components;
using Components.Enum;
using Core.Systems.Interface;
using Core.Util;
using UnityEngine;

namespace Systems
{
    public class MotionSystem:IStandardSystem
    {
        private List<GameObject> _entities;
        private Dictionary<GameObject, MotionComponent> _motionDictionary;
        private Dictionary<GameObject, TransformComponent> _transformDictionary;
        
        public void Initialize()
        {
            _entities = Main.MainProxy.GetEntitiesWithComponents<MotionComponent, TransformComponent>();
            _motionDictionary = _entities.ToComponentDictionary<MotionComponent>();
            _transformDictionary = _entities.ToComponentDictionary<TransformComponent>();
        }

        public void Tick()
        {
            foreach (var entity in _entities)
            {
                MotionComponent motionComponent = _motionDictionary[entity];
                switch (motionComponent.MoveType)
                {
                    case MoveType.SimpleMove:
                        ExcuteSimpleMove(_transformDictionary[entity], _motionDictionary[entity]);
                        break;
                    case MoveType.KeyboardMove:
                        ExcuteKeyboardMove(_transformDictionary[entity], _motionDictionary[entity]);
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
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            motion.Direction = new Vector2(inputX, inputY).normalized;
            transform.Translate(motion.Direction * (motion.Speed * Time.deltaTime));
        }
    }
}

