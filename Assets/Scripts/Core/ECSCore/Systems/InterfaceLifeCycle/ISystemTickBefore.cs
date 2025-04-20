namespace Core.ECSCore.Systems
{
    public interface ISystemTickBefore:ISystem
    {
        void BeforeTick(); 
    }
}