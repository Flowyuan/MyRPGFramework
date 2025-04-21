using System.Collections.Generic;
using UnityEngine;

namespace Core.ECSCore
{
    public static class InjectorManager
    {
        private static Injector[] _injectors;

        public static void Initialize()
        {
            _injectors = Object.FindObjectsByType<Injector>(FindObjectsSortMode.None);
        }

        public static void InjectComponentsToEntity()
        {
            foreach (var injector in _injectors)
            {
                injector.InjectToEntity();
            }
        }
    }
}