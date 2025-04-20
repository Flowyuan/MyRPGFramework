using System;
using System.Collections.Generic;
using System.Linq;
using Core.ECSCore.Systems;
using Core.Entities;
using Core.Systems;
using Core.Systems.Interface;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public static partial class SystemManager
    {
        private static readonly Type[] _systemCollections =
        {
            typeof(Component.Motion)
        };
        
        private static  List<ISystem> _systems;
        private static  List<ISystemTickBefore> _tickedSystems;
        private static List<ISystemInitalize> _initalizableSystems;
        private static  Dictionary<Type, List<ISystem>> _componentToSystem;
        public static void Initialize()
        {
            _systems = new();
            _tickedSystems = new();
            _initalizableSystems = new();
            _componentToSystem = new();
        }

        public static void SetupSystems()
        { 
            SystemSetupCommand.Excute();
        }
        
        public static void Tick()
        {
            TickSystems();
        }
        
        public static void TickSystems()
        {
            foreach (var sys in _tickedSystems)
            {
                sys.Tick();
            }
        }

        
    }
}