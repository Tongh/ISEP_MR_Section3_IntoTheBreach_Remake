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
        public string Description;
        public EAttackType AttackType;
        public int Damage;
        public int Range;
        public string Effect;
    }

    [Serializable]
    public struct EffectConfigData
    {
        public EffectData[] EffectsData;
    }

    [Serializable]
    public struct EffectData
    {
        public string EffectId;
        public string Description;
        public EEffectType EffectType;
        public int Damage;
        public string Direction; // 0 forwards, 1 backwards, 2 Left, 3 Right
        public int Value;
    }
}
