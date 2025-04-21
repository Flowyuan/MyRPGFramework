using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ECSCore
{
    public static class EntityPool
    {
        private static readonly Queue<int> _collectionQueue = new();
        private static bool[] entityExistMap = new bool[ECSSettings.EntityIDCapacity];

        private static int _currentMaxID = -1;

        public static int AllocateEntityID()
        {
            int entityID;
            if (_collectionQueue.Count == 0)
            {
                _currentMaxID += 1;
                entityID = _currentMaxID;
                if (_currentMaxID == ECSSettings.EntityIDCapacity)
                {
                    throw new OperationCanceledException
                        ($"[ECSEntityPool] 不存在能够分配的实体了，请调整最大实体容量---->Current_Capacity: {ECSSettings.EntityIDCapacity}");
                }
            }
            else
            {
                entityID = _collectionQueue.Dequeue();
            }
            
            entityExistMap[entityID] = true;
            return entityID;
        }

        public static void RealeaseEntityID(int entityID)
        {
            entityExistMap[entityID] = false;
            _collectionQueue.Enqueue(entityID);
        }

        public static bool ExistEntity(int entityID)
        {
            return entityExistMap[entityID];
        }
    }
}