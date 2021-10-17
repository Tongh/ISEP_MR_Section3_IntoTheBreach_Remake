using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface ISystemGround : ISystem
    {
        Material GetMateirialByGround(int GroundTypeInt);
        Vector2Int RandomBirthGround();
        FDataMapGround GetMapGroundConfigDataByGroundTypeInt(int GroundTypeInt);
        bool IsLocationValidForStanding(Vector2Int Loc2);
    }

    public class SystemGround : AbstractSystem, ISystemGround
    {
        private IModelGround mMapModel;
        private FDataAllMapGround mMapMakerConfigData;
        private FDataMapStyle mStyleMapConfigData;

        protected override void OnInit()
        {
            mMapModel = this.GetModel<IModelGround>();
            var storage = this.GetUtility<IStorage>();

            mMapMakerConfigData = storage.LoadMapMakerConfigData();
            mStyleMapConfigData = mMapMakerConfigData.Styles[Random.Range(0, mMapMakerConfigData.Styles.Length)];

            this.RegisterEvent<EventGamePrepare>(e =>
            {
                RandomMap();

                this.SendEvent<EventInitGround>();
            });
        }

        public Material GetMateirialByGround(int GroundTypeInt)
        {
            foreach (FDataMapGround eachGround in mStyleMapConfigData.Grounds)
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

        private string GetGroundMaterialRessourceString(ETypeGround GroundType)
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
                    if (mMapModel.GroundTypeMap[i, j].Value == (int)ETypeGround.Ground)
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
                    groundtype == (int)ETypeGround.Ground ||
                    groundtype == (int)ETypeGround.Special;

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

        public FDataMapGround GetMapGroundConfigDataByGroundTypeInt(int GroundTypeInt)
        {
            return mStyleMapConfigData.Grounds[GroundTypeInt];
        }

        public bool IsLocationValidForStanding(Vector2Int Loc2)
        {
            int groundtype = mMapModel.GroundTypeMap[Loc2.x, Loc2.y].Value;
            bool GroundCanStand =
                groundtype == (int)ETypeGround.Ground ||
                groundtype == (int)ETypeGround.Special ||
                groundtype == (int)ETypeGround.Water;

            bool someonehere = mMapModel.bIsSomeoneHereMap[Loc2.x, Loc2.y].Value;

            if (GroundCanStand && !someonehere)
            {
                return true;
            }

            return false;
        }
    }
}
