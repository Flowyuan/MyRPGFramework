namespace Core.ECSCore
{
    public interface IComponentList
    {
        public int Count { get; }
        void RemoveAtSwapBack(int index);
    }
}