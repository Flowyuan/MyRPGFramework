using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ECSCore
{
    public partial class Entity:MonoBehaviour
    {
        public int EntityID 
        { 
            get =>_entityID; 
            set =>_entityID = value;
        }
        
        [SerializeField] private int _entityID;

        public void AddComponent<T>() where T:struct, IComponent
        {
            ComponentManager.TryAddComponent<T>(_entityID, out var componentID);
        }

        public bool HasComponent<T>() where T:struct, IComponent
        {
            return ComponentManager.ContainsComponent<T>(_entityID);
        }

        public T ObtainComponent<T>() where T:struct, IComponent
        {
            ComponentManager.TryObtainComponent<T>(_entityID, out T component);
            return component;
        }
    }
}