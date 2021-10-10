using System;

namespace OutOfTheBreach
{
    [Serializable]
    public struct MechaConfigData
    {
        public MechaData[] MechasData;
    }

    [Serializable]
    public struct MechaData
    {
        public string MechaId;
        public string MechaName;
        public float Speed;
        public int Life;
    }
}
