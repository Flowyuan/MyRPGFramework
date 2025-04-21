using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        private static Dictionary<int, IList> _componetDenses;
        private static CommonMask[] _id2Mask;
        

        private static void Initialize()
        {
            int typeAmount = _componentCollections.Length;
            
            _type2ID = new();
            _componetDenses = new();
            _id2Mask = new CommonMask[typeAmount];
            
            for (int componentTypeID = 0; componentTypeID < typeAmount; ++componentTypeID)
            {
                Type componentType = _componentCollections[componentTypeID];
                
                _type2ID.Add(componentType, componentTypeID);
                
                //创建密集数组
                var listType = typeof(List<>).MakeGenericType(componentType);
                var list = Activator.CreateInstance(listType) as IList;
                _componetDenses.Add(componentTypeID, list);

                _id2Mask[componentTypeID] = new CommonMask(componentTypeID);
            }
        }

        public static CommonMask GetComponentMask(int componentID)
        {
            return _id2Mask[componentID];
        }
    }
}