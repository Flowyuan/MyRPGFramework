using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ECSCore.Components
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
        private static int[] _id2Mask;
        

        private static void Initialize()
        {
            
        }

        private static void ToMask(this int componetID)
        {
            
        }
    }
}