using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Core.ECSCore
{
    public static class ComponentManager
    {
        private static readonly Type[] _componentCollections =
        {
            typeof(Component.MotionComponent),
            typeof(Component.TransformComponent),
        };

        private static Dictionary<Type, int> _type2ID;
        private static Type[] _id2Type;
        
        private static IComponentList[] _typeIDToComponentDenses;
        private static int[][] _typeIDToEntitySparses;
        private static List<int>[] _typeIDToEntityMapping;
        

        private static void Initialize()
        {
            int typeAmount = _componentCollections.Length;
            _type2ID = new();
            _id2Type = new Type[typeAmount];
            _typeIDToComponentDenses = new IComponentList[typeAmount];
            _typeIDToEntitySparses = new int[typeAmount][];
            _typeIDToEntityMapping = new List<int>[typeAmount];

            
            for (int typeID = 0; typeID < typeAmount; ++typeID)
            {
                Type type = _componentCollections[typeID];
                
                _type2ID.Add(type, typeID);
                _id2Type[typeID] = type;
                
                var listType = typeof(ComponentList<>).MakeGenericType(type);
                _typeIDToComponentDenses[typeID] = Activator.CreateInstance(listType) as IComponentList;

                _typeIDToEntitySparses[typeID] = new int[ECSSettings.EntityIDCapacity];
                Array.Fill<int>(_typeIDToEntitySparses[typeID], -1);

                _typeIDToEntityMapping[typeID] = new List<int>();
            }
        }

        public static bool TryAddComponent<T>(int entityID, out int componentID) where T:struct, IComponent
        {
            T component = new T();
            return TryAddComponent<T>(entityID, component, out componentID);
        }

        public static bool TryAddComponent<T>(int entityID, T component, out int componentID) where T:struct, IComponent
        {
            int typeID = _type2ID[typeof(T)];
            var entitySparse = _typeIDToEntitySparses[typeID];
            var componentDense = _typeIDToComponentDenses[typeID] as ComponentList<T>;
            var entityMapping = _typeIDToEntityMapping[typeID];
            
            if(entitySparse[entityID] == -1){
                componentDense.Add(component);
                entityMapping.Add(entityID);
                componentID = componentDense.Count - 1;
                entitySparse[entityID] = componentID;
                return true;
            }
            else
            {
                componentID = -1;
                return false;
            }
        }

        public static void RemoveComponent<T>(int entityID)where T:struct, IComponent
        {
            int typeID = _type2ID[typeof(T)];
            var entitySparse = _typeIDToEntitySparses[typeID];
            var componentList = _typeIDToComponentDenses[typeID];
            var entityMapping = _typeIDToEntityMapping[typeID];

            if(entitySparse[entityID] != -1){
                int componentID = entitySparse[entityID];
                entitySparse[entityID] = -1;
                List<int> d = new();
                componentList.RemoveAtSwapBack(componentID);
                entityMapping.RemoveAtSwapBack(componentID);
            }
            else
            {
                
            }
        }
        
        public static bool TryObtainComponent<T>(int entityID, out T component) where T:struct, IComponent
        {
            int typeID = _type2ID[typeof(T)];
            var entitySparse = _typeIDToEntitySparses[typeID];
            

            var componentID = entitySparse[entityID];
            if (componentID != -1)
            {
                var componentList = _typeIDToComponentDenses[typeID] as ComponentList<T>;
                component = componentList[componentID];
                return true;
            }

            component = default;
            return false;
        }

        public static bool ContainsComponent<T>(int entityID) where T:struct, IComponent
        {
            int typeID = _type2ID[typeof(T)];
            var entitySparse = _typeIDToEntitySparses[typeID];
            var componentID = entitySparse[entityID];
            return componentID != -1 ? true : false;
        }

        public static void CheckEntityIDValid(int entityID)
        {
            if (!EntityPool.ExistEntity(entityID))
            {
                throw new OperationCanceledException
                    ($"[ECSComponentManager] 试图操作不存在的实体---->实体ID: {entityID}");
            }

        }
    }
}