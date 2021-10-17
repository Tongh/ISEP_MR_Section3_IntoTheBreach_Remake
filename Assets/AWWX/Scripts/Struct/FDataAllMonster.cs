using System;

namespace OutOfTheBreach
{
    [Serializable]
    public struct FDataAllMonster
    {
        public FDataMonster[] MonstersData;
    }

    [Serializable]
    public struct FDataMonster
    {
        public string MonsterId;
        public string Description;
        public int Speed;
        public int Life;
        public bool bIsFlying;
    }
}
