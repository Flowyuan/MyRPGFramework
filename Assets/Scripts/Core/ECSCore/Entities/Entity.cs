using System;
using System.Collections.Generic;
using Core.ECSCore.Components;
using UnityEngine;

namespace Core.ECSCore
{
    public partial class Entity:MonoBehaviour
    {
        private CommonMask _ownCommon;
        protected Dictionary<Type, RComponent> _type2Component = new() ;
        [SerializeField] protected List<RComponent> _components = new();

        public T AddComponent<T>() where T:RComponent
        {
            Type type = typeof(T);
            T component = Activator.CreateInstance<T>();
            if(_type2Component.TryGetValue(type, out RComponent list))
            {
                throw new();
            }
            _type2Component.Add(type, component);
            
            return component;
        }

        public bool HasComponent<T>() where T : RComponent
        {
            Type type = typeof(T);
            return _type2Component.ContainsKey(type);
        }

        public T ObtainComponent<T>() where T : RComponent
        {
            _type2Component.TryGetValue(typeof(T), out RComponent component);
            return component as T;
        }

        public void RemoveComponent<T>() where T : RComponent
        {
            _type2Component.Remove(typeof(T));
        }
    }
}