namespace Core.ECSCore
{
    public interface ISystemInitalizeAfter:ISystem
    {
        void AfterInitialize();
    }
}