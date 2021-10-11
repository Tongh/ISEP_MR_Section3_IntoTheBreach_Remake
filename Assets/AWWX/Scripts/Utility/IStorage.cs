using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IStorage : IUtility
    {
        MapMakerConfigData LoadMapMakerConfigData();
        MechaConfigData LoadMechaConfigData();
        MonsterConfigData LoadMonsterConfigData();
    }
}
