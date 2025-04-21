namespace Core.ECSCore
{
    public interface ISystemInitializeBefore:ISystem
    {
        void BeforeInitialize();
    }
}