using System;

namespace OutOfTheBreach
{
    [Serializable]
    public struct AbilityConfigData
    {
        public AbilityData[] AbilitiesData;
    }

    [Serializable]
    public struct AbilityData
    {
        public string AbilityId;
        public string AbilityName;
        public int Damage;
        public int Range;
        public EAttackType AttackType;
    }
}
