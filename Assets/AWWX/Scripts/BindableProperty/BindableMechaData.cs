using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class BindableMechaData
    {
        public BindableProperty<string> ID;
        public BindableProperty<string> NickName;
        public BindableProperty<string> MechaModel;
        public BindableProperty<int> Life;
        public BindableProperty<int> Speed;
        public BindableProperty<bool> bIsFlying;
        public BindableProperty<bool> bIsInPlace;
        public BindableProperty<bool> bIsAlive;
        public BindableProperty<Vector2Int> Position;
        public BindableProperty<Vector2Int> Direction;

        public BindableMechaData(string id)
        {
            ID = new BindableProperty<string>() { Value = id };
            NickName = new BindableProperty<string>() { Value = id };
            MechaModel = new BindableProperty<string>() { Value = "" };
            Life = new BindableProperty<int>() { Value = 0 };
            Speed = new BindableProperty<int>() { Value = 0 };
            bIsFlying = new BindableProperty<bool>() { Value = false };
            bIsInPlace = new BindableProperty<bool>() { Value = false };
            bIsAlive = new BindableProperty<bool>() { Value = true };
            Position = new BindableProperty<Vector2Int>() { Value = Vector2Int.zero };
            Direction = new BindableProperty<Vector2Int>() { Value = Vector2Int.up };
        }
    }
}
