using System;

namespace OutOfTheBreach
{
    [Serializable]
    public struct MonsterConfigData
    {
        public MonsterData[] MonstersData;
    }

    [Serializable]
    public struct MonsterData
    {
        public string MonsterId;
        public string Description;
        public int Speed;
        public int Life;
        public bool bIsFlying;
    }
}
