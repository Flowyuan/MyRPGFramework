using System;
using System.Collections.Generic;
using Core.Systems;
using Core.Systems.Interface;

namespace Manager
{
    public static partial class SystemManager
    {
        private static class SystemSetupCommand
        
        {
            public static void Excute()
            {
                CreateSystems();
                BindSystemToComponent();
            }

            private static void CreateSystems()
            {
                Type initSystemType = typeof(ISystem);
                Type tickedSystemType = typeof(ISystemTickBefore);
                foreach (var type in _systemCollections)
                {
                    ISystem instance = Activator.CreateInstance(type) as ISystem;
                    _systems.Add(instance);
                
                    if (tickedSystemType.IsAssignableFrom(type))
                    {
                        ISystemTickBefore systemTickBefore = instance as ISystemTickBefore;
                        _tickedSystems.Add(systemTickBefore);
                    }
                }
            }

            private static void BindSystemToComponent()
            {
                foreach (var sys in _systems)
                {
                    BindTheSystem(sys);
                }
            }

            private static void BindTheSystem(ISystem system)
            {
                if (system is IHolderForOneEntity sys1)
                {
                    var list = sys1.GetComponentTypesOne();
                    if (list == null || list.Count == 0)
                    {
                        throw new();
                    }
                    
                }
                
                if (system is ISystemWithBetaEntity sys2)
                {
                    var list = sys2.GetComponentTypesTwo();
                    if (list == null || list.Count == 0)
                    {
                        throw new();
                    }
                }

                if (system is IHorlderForThreeEntities sys3)
                {
                    var list = sys3.GetComponentTypesThree();
                    if (list == null || list.Count == 0)
                    {
                        throw new();
                    }
                }
                
                if (system is IFourEntitieses sys4)
                {
                    var list = sys4.GetComponentTypesFour();
                    if (list == null || list.Count == 0)
                    {
                        throw new();
                    }
                }
            }

            private static Type DoBind(ISystem system, List<Type> type)
            {
                type.ForEach(type =>
                {
                    if (_componentToSystem.ContainsKey(type))
                    {
                        
                    }
                    else
                    {
                        // _componentToSystem.Add(type, new List<RSystem>);
                    }
                });
                return null;
            }
        }
    }

    
}