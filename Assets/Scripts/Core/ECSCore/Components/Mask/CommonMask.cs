namespace Core.ECSCore
{
    public class CommonMask
    {
        private static readonly CommonMask MaskBuffer = new(ECSSettings.ComponentTypeNum);

        private ulong[] _mask;

        public ulong this[int index]
        {
            get => _mask[index];
            set => _mask[index] = value;
        }

        public bool this[ index]
        {
            get => _mask[s];
            set => _mask[s] = value;
        }

        public CommonMask(int componentTypeID)
        {
            int ulongIndex = ECSSettings.ComponentTypeNum;
            int bitsIndex = componentTypeID/ECSDefine.BitsLength;
            _mask = new ulong[ECSSettings.ComponentTypeNum];
            _mask[ulongIndex] = 1ul << bitsIndex;
        }

        public CommonMask()
        {
            _mask = new ulong[ECSSettings.ComponentTypeNum];
        }

        public static CommonMask operator &(CommonMask mask1, CommonMask mask2)
        {
            for (int i = 0; i < ECSSettings.ComponentTypeNum; ++i)
            {
                MaskBuffer[i] = mask1[i] & mask2[i];
            }
            return MaskBuffer;
        }

        public static CommonMask operator |(CommonMask mask1, CommonMask mask2)
        {
            for (int i = 0; i < ECSSettings.ComponentTypeNum; ++i)
            {
                MaskBuffer[i] = mask1[i] | mask2[i];
            }
            return MaskBuffer;
        }
    }
}