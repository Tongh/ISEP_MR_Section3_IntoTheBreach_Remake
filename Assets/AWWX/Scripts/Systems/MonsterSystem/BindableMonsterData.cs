using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class BindableMonsterData
    {
        public MonsterData monsterData;

        public BindableProperty<int> ID;
        public BindableProperty<string> MonsterModel;
        public BindableProperty<int> Life;
        public BindableProperty<int> MaxLife;
        public BindableProperty<int> Speed;
        public BindableProperty<bool> bIsFlying;
        public BindableProperty<bool> bIsInPlace;
        public BindableProperty<bool> bIsAlive;
        public BindableProperty<Vector2Int> Position;
        public BindableProperty<Vector2Int> Direction;

        public BindableMonsterData(int id)
        {
            ID = new BindableProperty<int>() { Value = id };
            MonsterModel = new BindableProperty<string>() { Value = "" };
            Life = new BindableProperty<int>() { Value = 0 };
            MaxLife = new BindableProperty<int>() { Value = 0 };
            Speed = new BindableProperty<int>() { Value = 0 };
            bIsFlying = new BindableProperty<bool>() { Value = false };
            bIsInPlace = new BindableProperty<bool>() { Value = false };
            bIsAlive = new BindableProperty<bool>() { Value = false };
            Position = new BindableProperty<Vector2Int>() { Value = Vector2Int.zero };
            Direction = new BindableProperty<Vector2Int>() { Value = Vector2Int.up };
        }
    }
}
