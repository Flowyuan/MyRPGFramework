using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;

namespace Core.ECSCore
{
    public class ComponentList<T>:IComponentList where T:struct, IComponent
    {
        private List<T> _list = new();

        public int Count => _list.Count;
        
        public T this[int index]{
            get => _list[index];
            set => _list[index] = value;
        }

        public void Add(T component)
        {
            _list.Add(component);
        }

        public void RemoveAtSwapBack(int index)
        {
            _list.RemoveAtSwapBack(index);
        }
    }
}