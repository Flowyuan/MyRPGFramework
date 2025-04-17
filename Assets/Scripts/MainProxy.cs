using System;
using System.Collections.Generic;
using System.Linq;
using Core.Components;
using Core.Util;
using UnityEngine;


public partial class Main{
    public static class MainProxy
    {
        private static Main _main;
    
        private static Main Main
        {
            get
            {
                if (_main == null)
                {
                    _main = FindAnyObjectByType<Main>();
                }
    
                return _main;
            }
        }
        
        public static List<GameObject> GetEntitiesWithComponents<T>() where T:MComponent
        {
            return Main._entities.Where(entity =>
                entity.HasComponent<T>()
            ).ToList();
        }
        
        public static List<GameObject> GetEntitiesWithComponents<T1, T2>() 
            where T1:MComponent
            where T2:MComponent
        {
            return Main._entities.Where(entity =>
                entity.HasComponent<T1>() &&
                entity.HasComponent<T2>()
            ).ToList();
        }
        
        public static List<GameObject> GetEntitiesWithComponents<T1, T2, T3>() 
            where T1:MComponent
            where T2:MComponent
            where T3:MComponent
        {
            return Main._entities.Where(entity =>
                entity.HasComponent<T1>() &&
                entity.HasComponent<T2>() &&
                entity.HasComponent<T3>()
            ).ToList();
        }
        
        public static List<GameObject> GetEntitiesWithComponents<T1, T2, T3, T4>() 
            where T1:MComponent
            where T2:MComponent
            where T3:MComponent
            where T4:MComponent
        {
            return Main._entities.Where(entity =>
                entity.HasComponent<T1>() &&
                entity.HasComponent<T2>() &&
                entity.HasComponent<T3>() &&
                entity.HasComponent<T4>()
            ).ToList();
        }
    }
}
