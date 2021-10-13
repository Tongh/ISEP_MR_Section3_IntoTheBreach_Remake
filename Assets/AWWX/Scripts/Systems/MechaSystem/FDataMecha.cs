using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class FDataMecha
    {
        public BindableProperty<int> ID;
        public BindableProperty<string> NickName;
        public BindableProperty<string> MechaModel;
        public BindableProperty<int> Life;
        public BindableProperty<int> Speed;
        public BindableProperty<bool> bIsFlying;
        public BindableProperty<bool> bIsInPlace;
        public BindableProperty<bool> bIsAlive;
        public BindableProperty<Vector2Int> Position;
        public BindableProperty<Vector2Int> Direction;

        public FDataMecha(int id)
        {
            ID = new BindableProperty<int>() { Value = id };
            NickName = new BindableProperty<string>() { Value = "" };
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
