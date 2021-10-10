using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface IMapMakerSystem : ISystem
    {
        Material GetMateirialByGround(int GroundTypeInt);
    }

    public class MapMakerSystem : AbstractSystem, IMapMakerSystem
    {
        private IMapModel mMapModel;
        public MapMakerConfigData mapMakerConfigData;
        public StyleMapConfigData styleMapConfigData;

        protected override void OnInit()
        {
            Debug.Log("Map Maker System Loaded");

            mMapModel = this.GetModel<IMapModel>();
            var storage = this.GetUtility<IStorage>();

            mapMakerConfigData = storage.LoadMapMakerConfigData();
            styleMapConfigData = mapMakerConfigData.Styles[Random.Range(0, mapMakerConfigData.Styles.Length)];

            this.RegisterEvent<GamePrepareEvent>(e =>
            {
                RandomMap();
            });
        }

        public Material GetMateirialByGround(int GroundTypeInt)
        {
            foreach (MapGroundConfigData eachGround in styleMapConfigData.Grounds)
            {
                if (GroundTypeInt == ((int)eachGround.GroundType))
                {
                    Material mat = Resources.Load(eachGround.GroundMaterial, typeof(Material)) as Material;
                    Assert.IsNotNull(mat, "Material is null!");
                    return mat;
                }
            }
            Debug.LogError("Material is null! ");
            return null;
        }

        public void RandomMap()
        {
            RandomGroundType();
        }

        private void RandomGroundType()
        {
            int[] prob = new int[] { 80, 5, 5, 5, 5 };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mMapModel.Map[i, j].Value == 0)
                    {
                        mMapModel.Map[i, j].Value = RandomLibrary.randAdd(prob, 100);
                    }
                }
            }
        }
    }
}
