using System;
using UnityEngine;

namespace Core.ECSCore
{
    [Serializable]
    public class RComponent
    {
        [SerializeField] private string _name;

        public RComponent()
        {
            _name = this.GetType().Name;
        }
    }
}