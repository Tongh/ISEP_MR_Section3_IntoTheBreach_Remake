using System;

namespace OutOfTheBreach
{
    [Serializable]
    public struct FDataAllAbility
    {
        public FDataAbility[] AbilitiesData;
    }

    [Serializable]
    public struct FDataAbility
    {
        public string AbilityId;
        public string Description;
        public EAttackType AttackType;
        public int Damage;
        public int Range;
        public string Effect;
    }

    [Serializable]
    public struct FDataAllEffect
    {
        public FDataEffect[] EffectsData;
    }

    [Serializable]
    public struct FDataEffect
    {
        public string EffectId;
        public string Description;
        public EEffectType EffectType;
        public int Damage;
        public string Direction; // 0 forwards, 1 backwards, 2 Left, 3 Right
        public int Value;
    }
}
