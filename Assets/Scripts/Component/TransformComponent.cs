using System;
using Core.ECSCore.Components;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.UIElements;

namespace Component
{
    [Serializable]
    public class TransformComponent : IComponent
    {
        public Transform EntityTransform;

        public TransformComponent()
        {
        }

        public Vector3 LocalPosition {
            get => EntityTransform.localPosition;
            set => EntityTransform.localPosition = value;
        }

        public Vector3 Position {
            get => EntityTransform.position;
            set => EntityTransform.position = value;
        }

        public void Translate(Vector3 translation)
        {
            EntityTransform.Translate(translation, Space.Self);
        }
        
        public void Translate(Vector3 translation, [DefaultValue("Space.Self")] Space relativeTo)
        {
            EntityTransform.Translate(translation, relativeTo);
        }

        public TransformComponent(Transform transform)
        {
            this.EntityTransform = transform;
        }
    }
}



