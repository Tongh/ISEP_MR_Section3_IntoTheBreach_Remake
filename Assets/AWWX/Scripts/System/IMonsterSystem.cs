using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public interface IMonsterSystem : ISystem
    {

    }

    public class MonsterSystem : AbstractSystem, IMonsterSystem
    {
        private IGameModel mGameModel;
        private IMonsterModel mMonsterModel;
        private IMapMakerSystem mMapMakerSystem;
        private MonsterConfigData mMonsterConfigData;

        protected override void OnInit()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMonsterModel = this.GetModel<IMonsterModel>();
            mMapMakerSystem = this.GetSystem<IMapMakerSystem>();
            var storage = this.GetUtility<IStorage>();

            mMonsterConfigData = storage.LoadMonsterConfigData();

            this.RegisterEvent<GamePrepareEvent>(e =>
            {
                MakeMonsters();

                this.SendEvent<MonsterComeEvent>();
            });
        }

        private void MakeMonsters()
        {

        }

        private void RandomMonster()
        {
            int monster = Random.Range(0, GetMonstersTypeNum());
            Vector2Int position = mMapMakerSystem.RandomBirthGround();

            //mMonsterModel.Monsters.bIsAlive.Value = true;
            //mMonsterModel.Monsters.MonsterModel.Value = GetMonsterIdByIndex(monster);
        }

        public int GetMonstersTypeNum()
        {
            return mMonsterConfigData.MonstersData.Length;
        }

        public MonsterData GetMonsterDataByIndex(int index)
        {
            return mMonsterConfigData.MonstersData[index];
        }

        public string GetMonsterIdByIndex(int index)
        {
            return mMonsterConfigData.MonstersData[index].MonsterId;
        }
    }
}
