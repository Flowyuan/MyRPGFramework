using System;
using Components.Enum;
using Core.ECSCore.Components;
using UnityEngine;

namespace Component
{
    [Serializable]
    public class MotionComponent : IComponent
    {
        [SerializeField] private MoveType _moveType ;
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _direction;
        
        public MotionComponent()
        {
        }
        
        public MoveType MoveType
        {
            get => _moveType;
            set => _moveType = value;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }
    }
}


