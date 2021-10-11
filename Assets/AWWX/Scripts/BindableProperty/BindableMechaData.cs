using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class BindableMechaData
    {
        public BindableProperty<string> ID;
        public BindableProperty<string> NickName;
        public BindableProperty<string> Model;
        public BindableProperty<int> Life;
        public BindableProperty<int> Speed;
        public BindableProperty<bool> bIsFlying;
        public BindableProperty<Vector2Int> Position;
    }
}
