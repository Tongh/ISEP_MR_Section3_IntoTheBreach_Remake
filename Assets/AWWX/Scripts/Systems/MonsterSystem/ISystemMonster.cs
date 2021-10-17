using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface ISystemMonster : ISystem
    {
        Material GetMateirialByMonsterType(string MonsterType);
        FDataMonster GetMonsterDataByIndex(int index);
        FDataMonster GetMonsterDataById(string id);
        int GetMonsterIndexById(string id);
    }

    public class SystemMonster : AbstractSystem, ISystemMonster
    {
        private IGameModel mGameModel;
        private IModelMonster mMonsterModel;
        private ISystemGround mMapMakerSystem;
        private FDataAllMonster mMonsterConfigData;

        protected override void OnInit()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMonsterModel = this.GetModel<IModelMonster>();
            mMapMakerSystem = this.GetSystem<ISystemGround>();
            var storage = this.GetUtility<IStorage>();

            mMonsterConfigData = storage.LoadMonsterConfigData();

            this.RegisterEvent<EventInitMonster>(e =>
            {
                MakeMonstersData();

                Assert.IsTrue(mGameModel.GameState.Value == (int)EGameState.MonsterPreparing, nameof(EGameState.MonsterComing) + " must after " + nameof(EGameState.MonsterPreparing));
                mGameModel.GameState.Value = (int)EGameState.MonsterComing;

                this.SendEvent<EventMonsterCome>();
            });
        }

        private void MakeMonstersData()
        {
            int InitialEnemyNum = mGameModel.Difficulty.Value == (int)EGameDifficulty.HARD ? 5 : 4;
            for (int i = 0; i < InitialEnemyNum; i++)
            {
                RandomMonster();
            }
        }

        private void RandomMonster()
        {
            int monstertype = Random.Range(0, GetMonstersTypeNum());
            Vector2Int position = mMapMakerSystem.RandomBirthGround();

            int monsterindex = GetNextNewMonsterIndex();

            mMonsterModel.Monsters[monsterindex].MonsterModel.Value = GetMonsterIdByIndex(monstertype);
            mMonsterModel.Monsters[monsterindex].Position.Value = position;
            mMonsterModel.Monsters[monsterindex].bIsAlive.Value = true;
        }

        public int GetMonstersTypeNum()
        {
            return mMonsterConfigData.MonstersData.Length;
        }

        public FDataMonster GetMonsterDataByIndex(int index)
        {
            return mMonsterConfigData.MonstersData[index];
        }

        public string GetMonsterIdByIndex(int index)
        {
            return mMonsterConfigData.MonstersData[index].MonsterId;
        }

        public int GetMonsterIndexById(string id)
        {
            for (int i = 0; i < mMonsterConfigData.MonstersData.Length; i++)
            {
                if (mMonsterConfigData.MonstersData[i].MonsterId.Equals(id))
                {
                    return i;
                }
            }
            Assert.IsTrue(false, id + " Monster not found!");
            return -1;
        }

        public int GetNextNewMonsterIndex()
        {
            for (int i = 0; i < mMonsterModel.Monsters.Length; i++)
            {
                if (!mMonsterModel.Monsters[i].bIsAlive.Value)
                {
                    return i;
                }
            }
            return -1;
        }

        public Material GetMateirialByMonsterType(string MonsterType)
        {
            string MatRes = GetMonsterMaterialRessourceString(MonsterType);
            Material mat = Resources.Load(MatRes, typeof(Material)) as Material;
            Assert.IsNotNull(mat, MatRes + " is null!");
            return mat;
        }

        private string GetMonsterMaterialRessourceString(string MonsterType)
        {
            return "Materials/Monster/M_Monster_" + MonsterType;
        }

        public FDataMonster GetMonsterDataById(string id)
        {
            return GetMonsterDataByIndex(GetMonsterIndexById(id));
        }
    }
}
