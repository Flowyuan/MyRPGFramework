namespace Core.ECSCore.Systems
{
    public interface ISystemTickAfter:ISystem
    {
        void AfterTick(); 
    }
}