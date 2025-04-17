using Core.Components;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.UIElements;

namespace Components
{
    public class TransformComponent : MComponent
    {
        public Vector3 LocalPosition {
            get => transform.localPosition;
            set => transform.localPosition = value;
        }

        public Vector3 Position {
            get => transform.position;
            set => transform.position = value;
        }

        public void Translate(Vector3 translation)
        {
            transform.Translate(translation, Space.Self);
        }
        
        public void Translate(Vector3 translation, [DefaultValue("Space.Self")] Space relativeTo)
        {
            transform.Translate(translation, relativeTo);
        }
    }
}



