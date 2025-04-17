using System.Collections.Generic;
using System.Linq;
using Core.Components;
using UnityEngine;

namespace Core.Util
{
    public static class CoreUtil
    {
        public static bool HasComponent<T>(this GameObject gameObject) where T:MComponent
        { 
            if (gameObject.GetComponent<T>() != null)
            {
                return true;
            }
            return false;
        }

        public static Dictionary<GameObject, T> ToComponentDictionary<T>(this List<GameObject> list) where T:MComponent
        {
            Dictionary<GameObject, T> dictionary = new();
            foreach (var obj in list)
            {
                T component = obj.GetComponent<T>();
                if (component)
                {
                    dictionary.Add(obj, component);
                }
            }

            return dictionary;
        }
    }
}