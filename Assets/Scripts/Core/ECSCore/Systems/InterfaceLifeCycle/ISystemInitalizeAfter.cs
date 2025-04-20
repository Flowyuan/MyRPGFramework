namespace Core.ECSCore.Systems
{
    public interface ISystemInitalizeAfter:ISystem
    {
        void AfterInitialize();
    }
}