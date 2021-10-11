using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface IMechaSystem : ISystem
    {
        string GetMechaIdByInt(int index);
        int GetMechaindexById(string id);
        int GetMechasNum();
        MechaData GetMechaDataById(string id);
        MechaData GetMechaDataByInt(int index);
    }

    public class MechaSystem : AbstractSystem, IMechaSystem
    {
        private IGameModel mGameModel;
        private IMechaModel mMechaModel;
        private MechaConfigData mMechaConfigData;

        protected override void OnInit()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMechaModel = this.GetModel<IMechaModel>();
            var storage = this.GetUtility<IStorage>();

            mMechaConfigData = storage.LoadMechaConfigData();


            for (int i = 0; i < mGameModel.MechaModels.Length; i++)
            {
                mGameModel.MechaModels[i].Value = mMechaConfigData.MechasData[i].MechaId;
            }

            this.RegisterEvent<GamePrepareEvent>(e =>
            {
                this.SendEvent<InitMechaEvent>();
            });

            this.RegisterEvent<MechaInPlacingEvent>(e =>
            {
            });
        }

        public string GetMechaIdByInt(int index)
        {
            return mMechaConfigData.MechasData[index].MechaId;
        }

        public int GetMechaindexById(string id)
        {
            for (int i = 0; i < mMechaConfigData.MechasData.Length; i++)
            {
                if (id.Equals(mMechaConfigData.MechasData[i].MechaId))
                {
                    return i;
                }
            }
            Assert.IsTrue(false, "Mecha id " + id + " Not Found!");
            return -1;
        }

        public int GetMechasNum()
        {
            return mMechaConfigData.MechasData.Length;
        }

        public MechaData GetMechaDataById(string id)
        {
            for (int i = 0; i < mMechaConfigData.MechasData.Length; i++)
            {
                if (id.Equals(mMechaConfigData.MechasData[i].MechaId))
                {
                    return mMechaConfigData.MechasData[i];
                }
            }
            Assert.IsTrue(false, "Mecha id " + id + " Not Found!");
            return new MechaData();
        }

        public MechaData GetMechaDataByInt(int index)
        {
            return GetMechaDataById(GetMechaIdByInt(index));
        }
    }
}
