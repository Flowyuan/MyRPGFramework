namespace Core.ECSCore
{
    public interface ISystemTickAfter:ISystem
    {
        void AfterTick(); 
    }
}