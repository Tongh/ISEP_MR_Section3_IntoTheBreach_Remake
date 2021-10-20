using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class FPropertyMecha
    {
        public FDataMecha mechaData;

        public BindableProperty<int> ID;
        public BindableProperty<string> NickName;
        public BindableProperty<string> MechaModel;
        public BindableProperty<int> Life;
        public BindableProperty<int> MaxLife;
        public BindableProperty<int> Speed;
        public BindableProperty<bool> bIsFlying;
        public BindableProperty<bool> bIsInPlace;
        public BindableProperty<bool> bIsInPlacing;
        public BindableProperty<bool> bIsAlive;
        public BindableProperty<Vector2Int> Position;
        public BindableProperty<Vector2Int> Direction;

        public FPropertyMecha(int id)
        {
            mechaData = new FDataMecha();
            ID = new BindableProperty<int>() { Value = id };
            NickName = new BindableProperty<string>() { Value = "" };
            MechaModel = new BindableProperty<string>() { Value = "" };
            Life = new BindableProperty<int>() { Value = 0 };
            MaxLife = new BindableProperty<int>() { Value = 0 };
            Speed = new BindableProperty<int>() { Value = 0 };
            bIsFlying = new BindableProperty<bool>() { Value = false };
            bIsInPlace = new BindableProperty<bool>() { Value = false };
            bIsInPlacing = new BindableProperty<bool>() { Value = false };
            bIsAlive = new BindableProperty<bool>() { Value = true };
            Position = new BindableProperty<Vector2Int>() { Value = Vector2Int.zero };
            Direction = new BindableProperty<Vector2Int>() { Value = Vector2Int.up };
        }

        public void InitByMechaData(FDataMecha inMechaData)
        {
            mechaData = inMechaData;
            NickName.Value = mechaData.MechaId + "-" + ID.ToString();
            MechaModel.Value = mechaData.MechaId;
            Life.Value = mechaData.Life;
            MaxLife.Value = mechaData.Life;
            Speed.Value = mechaData.Speed;
            bIsFlying.Value = mechaData.bIsFlying;
            bIsAlive.Value = true;
            bIsInPlace.Value = true;
        }
    }
}
