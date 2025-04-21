namespace Core.ECSCore.Utils
{
    public static class ECSUtils
    {
        private static CommonMask ToComponentMask(this int componetID)
        {
            return ComponentManager.GetComponentMask(componetID);
        }

        private static int ToComponentID(this CommonMask commonMask)
        {
            for (int i = 0; i < ECSSettings.ComponentTypeNum; ++i)
            {
                if (commonMask[i] != 0)
                {
                    return commonMask[i]
                }
            }
        }

        private static int TpComponentIDs(this CommonMask commonMask)
        {
            
        }
    }
}