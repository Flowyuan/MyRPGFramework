namespace Core.ECSCore
{
    public interface ISystemTickBefore:ISystem
    {
        void BeforeTick(); 
    }
}