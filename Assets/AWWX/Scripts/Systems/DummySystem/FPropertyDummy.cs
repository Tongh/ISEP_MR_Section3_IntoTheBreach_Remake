using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class FPropertyDummy
    {
        public GameObject PrefabObject;
        public BindableProperty<bool> bIsMonster;
        public BindableProperty<string> ModelId;
        public BindableProperty<Vector2Int> Position;
        public BindableProperty<Vector2Int> Direction;
    }
}
