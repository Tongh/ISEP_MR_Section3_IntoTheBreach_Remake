using FrameworkDesign;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface ISystemGround : ISystem
    {
        Material GetMateirialByGround(int GroundTypeInt);
        bool GetDecorationByGround(int GroundTypeInt, out GameObject PrefabObject);
        Vector2Int RandomBirthGround();
        FDataMapGround GetMapGroundConfigDataByGroundTypeInt(int GroundTypeInt);
        bool IsLocationValidForStanding(Vector2Int Loc2);
        Vector2Int GetRandomTargetLocCanAttack(Vector2Int MyLoc, int Speed, out Vector2Int StandPosition);
        Vector2Int GetLocToAttack(Vector2Int Target, Vector2Int MyLoc, int Speed);
        List<Vector2Int> GetAllLocationsCanMoveTo(Vector2Int MyLoc, int Speed);
        void EntityStandingChanged(int x, int y, int type);
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

                int someonehere = mMapModel.StandingMap[i, j].Value;

                if (GroundCanStand && someonehere == 0)
                {
                    ret.x = i;
                    ret.y = j;

                    mMapModel.StandingMap[i, j].Value = 2;

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

            int someonehere = mMapModel.StandingMap[Loc2.x, Loc2.y].Value;

            if (GroundCanStand && someonehere == 0)
            {
                return true;
            }

            return false;
        }

        private Dictionary<Vector2Int, List<Vector2Int>> GetAllTargetLocCanAttack(List<Vector2Int> AllLocs)
        {
            Dictionary<Vector2Int, List<Vector2Int>> map = new Dictionary<Vector2Int, List<Vector2Int>>();

            foreach (Vector2Int eachLoc in AllLocs)
            {
                List<Vector2Int> temp = new List<Vector2Int>();
                foreach (Vector2Int eachAdjcent in GetAdjcentLocs(eachLoc))
                {
                    int StandingUnit = mMapModel.StandingMap[eachAdjcent.x, eachAdjcent.y].Value;
                    //if (StandingUnit == 1 || StandingUnit == 3)
                    if (StandingUnit == 3)
                    {
                        temp.Add(eachAdjcent);
                    }
                }

                if (temp.Count > 0)
                {
                    map.Add(eachLoc, temp);
                }
            }

            return map;
        }

        private List<Vector2Int> GetAdjcentLocs(Vector2Int loc)
        {
            List<Vector2Int> ret = new List<Vector2Int>();

            if (loc.x > 0)
            {
                ret.Add(new Vector2Int(loc.x - 1, loc.y));
            }
            if (loc.x < 7)
            {
                ret.Add(new Vector2Int(loc.x + 1, loc.y));
            }
            if (loc.y > 0)
            {
                ret.Add(new Vector2Int(loc.x, loc.y - 1));
            }
            if (loc.y < 7)
            {
                ret.Add(new Vector2Int(loc.x, loc.y + 1));
            }

            return ret;
        }

        public List<Vector2Int> GetAllLocationsCanMoveTo(Vector2Int MyLoc, int Speed)
        {
            List<Vector2Int> ret = new List<Vector2Int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int Distance = MyLoc.x - i + MyLoc.y - j;
                    if (Distance <= Speed && IsLocationValidForStanding(new Vector2Int(i, j)))
                    {
                        ret.Add(new Vector2Int(i, j));
                    }
                }
            }

            return ret;
        }

        public Vector2Int GetRandomTargetLocCanAttack(Vector2Int MyLoc, int Speed, out Vector2Int StandPosition)
        {
            List<Vector2Int> allLocsCanMoveTo = GetAllLocationsCanMoveTo(MyLoc, Speed);
            Dictionary<Vector2Int, List<Vector2Int>> allTargetLocsCanAttack = GetAllTargetLocCanAttack(allLocsCanMoveTo);
            List<Vector2Int> Keys = new List<Vector2Int>(allTargetLocsCanAttack.Keys);

            if (Keys.Count < 1)
            {
                StandPosition = allLocsCanMoveTo[Random.Range(0, allLocsCanMoveTo.Count)];
                return new Vector2Int(-1, -1);
            }

            StandPosition = Keys[Random.Range(0, Keys.Count)];
            
            List<Vector2Int> Value =allTargetLocsCanAttack[StandPosition];

            return Value[Random.Range(0, Value.Count)];
        }

        public Vector2Int GetLocToAttack(Vector2Int Target, Vector2Int MyLoc, int Speed)
        {
            List<Vector2Int> allLocsCanMoves = GetAllLocationsCanMoveTo(MyLoc, Speed);
            if (Target == new Vector2Int(-1, -1))
            {
                return allLocsCanMoves[Random.Range(0, allLocsCanMoves.Count)];
            }
            List<Vector2Int> possibles = new List<Vector2Int>();
            foreach (Vector2Int eachLoc in allLocsCanMoves)
            {
                foreach (Vector2Int eachAdjcent in GetAdjcentLocs(eachLoc))
                {
                    if (Target == eachAdjcent)
                    {
                        possibles.Add(eachAdjcent);
                    }
                }
            }
            return possibles[Random.Range(0, possibles.Count)];
        }

        public void EntityStandingChanged(int x, int y, int type)
        {
            mMapModel.StandingMap[x, y].Value = type;
        }

        public bool GetDecorationByGround(int GroundTypeInt, out GameObject PrefabObject)
        {
            PrefabObject = null;
            foreach (FDataMapGround eachGround in mStyleMapConfigData.Grounds)
            {
                if (GroundTypeInt == ((int)eachGround.GroundType))
                {
                    string PrefabRes = GetGroundDecorationRessourceString(eachGround.GroundType);
                    PrefabObject = Resources.Load(PrefabRes, typeof(GameObject)) as GameObject;

                    return PrefabObject != null;
                }
            }
            Assert.IsTrue(false, "Prefab is null!");
            return false;
        }

        private string GetGroundDecorationRessourceString(ETypeGround GroundType)
        {
            return "Prefabs/Decoration/" + GroundType.ToString();
        }
    }
}
