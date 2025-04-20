using System.Collections.Generic;
using System.Linq;
using Core.Components;
using UnityEngine;

namespace Core.ComponentManager
{
    public static class ComponentManager
    {
        private static List<RInjector> _injectors = new() ;
        
        public static void Initialize()
        {
        }
        
        public static void CollectAllInjector()
        {
            _injectors = Object.FindObjectsByType<RInjector>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
        }

        public static void InjectToEntities()
        {
            foreach (var injector in _injectors)
            {
                injector.InjectToEntity();   
            }
        }
    }
}