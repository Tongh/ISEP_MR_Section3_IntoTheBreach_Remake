using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface IMapMakerSystem : ISystem
    {
        Material GetMateirialByGround(int GroundTypeInt);
        Vector2Int RandomBirthGround();
        MapGroundConfigData GetMapGroundConfigDataByGroundTypeInt(int GroundTypeInt);
    }

    public class MapMakerSystem : AbstractSystem, IMapMakerSystem
    {
        private IMapModel mMapModel;
        private MapMakerConfigData mMapMakerConfigData;
        private StyleMapConfigData mStyleMapConfigData;

        protected override void OnInit()
        {
            mMapModel = this.GetModel<IMapModel>();
            var storage = this.GetUtility<IStorage>();

            mMapMakerConfigData = storage.LoadMapMakerConfigData();
            mStyleMapConfigData = mMapMakerConfigData.Styles[Random.Range(0, mMapMakerConfigData.Styles.Length)];

            this.RegisterEvent<GamePrepareEvent>(e =>
            {
                RandomMap();

                this.SendEvent<InitGroundEvent>();
            });
        }

        public Material GetMateirialByGround(int GroundTypeInt)
        {
            foreach (MapGroundConfigData eachGround in mStyleMapConfigData.Grounds)
            {
                if (GroundTypeInt == ((int)eachGround.GroundType))
                {
                    string MatRes = GetGroundMaterialRessourceString(eachGround.GroundType); 
                    Material mat = Resources.Load(MatRes, typeof(Material)) as Material;
                    Assert.IsNotNull(mat, "Material is null!");
                    return mat;
                }
            }
            Assert.IsTrue(false, "Material is null!");
            return null;
        }

        private string GetGroundMaterialRessourceString(EMapGroundType GroundType)
        {
            return "Materials/Ground/M_" + GroundType.ToString() + "_" + mStyleMapConfigData.StyleId;
        }

        public void RandomMap()
        {
            RandomGroundType();

            //TODO Enhance continuity of the same type
        }

        private void RandomGroundType()
        {
            int[] prob = new int[] { 80, 5, 5, 5, 5 };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mMapModel.GroundTypeMap[i, j].Value == (int)EMapGroundType.Ground)
                    {
                        mMapModel.GroundTypeMap[i, j].Value = RandomLibrary.randAdd(prob, 100);
                    }
                }
            }
        }

        public Vector2Int RandomBirthGround()
        {
            Vector2Int ret = new Vector2Int();
            bool finded = false;
            do
            {
                int i = Random.Range(0, 8);
                int j = Random.Range(0, 8);

                int groundtype = mMapModel.GroundTypeMap[i, j].Value;
                bool GroundCanStand =
                    groundtype == (int)EMapGroundType.Ground ||
                    groundtype == (int)EMapGroundType.Special;

                bool someonehere = mMapModel.bIsSomeoneHereMap[i, j].Value;

                if (GroundCanStand && !someonehere)
                {
                    ret.x = i;
                    ret.y = j;

                    mMapModel.bIsSomeoneHereMap[i, j].Value = true;

                    finded = true;
                }

            } while (!finded);

            return ret;
        }

        public MapGroundConfigData GetMapGroundConfigDataByGroundTypeInt(int GroundTypeInt)
        {
            return mStyleMapConfigData.Grounds[GroundTypeInt];
        }
    }
}
