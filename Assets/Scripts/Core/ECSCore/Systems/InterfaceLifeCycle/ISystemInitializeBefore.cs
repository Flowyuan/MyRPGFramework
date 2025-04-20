namespace Core.ECSCore.Systems
{
    public interface ISystemInitializeBefore:ISystem
    {
        void BeforeInitialize();
    }
}