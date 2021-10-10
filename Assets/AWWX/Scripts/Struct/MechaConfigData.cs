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
        public string MechaDescription;
        public int Speed;
        public int Life;
        public bool bIsFlying;
    }
}
