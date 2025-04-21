namespace Core.ECSCore
{
    public class ComponetUniqueMask
    {
        private CommonMask _commonMask;
        

        public ComponetUniqueMask(int componentID)
        {
            _commonMask = new(componentID);
        }
    }
}