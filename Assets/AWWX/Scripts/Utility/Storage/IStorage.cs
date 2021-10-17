using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IStorage : IUtility
    {
        FDataAllMapGround LoadMapMakerConfigData();
        FDataAllMecha LoadMechaConfigData();
        FDataAllMonster LoadMonsterConfigData();
    }
}
