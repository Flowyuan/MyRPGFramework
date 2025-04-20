using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Systems.Interface;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public static partial class EntityManager
    {
        private static List<Entity> _entities;

        public static List<Entity> Entities => _entities;

        public static void Initialize()
        {
        }

        public static void CollectAllEntities()
        {
            _entities = Object.FindObjectsByType<Entity>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
        }
    }
}