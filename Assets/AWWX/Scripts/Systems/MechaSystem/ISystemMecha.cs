using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface ISystemMecha : ISystem
    {
        string GetMechaIdByInt(int index);
        int GetMechaindexById(string id);
        int GetMechasNum();
        FDataMecha GetMechaDataById(string id);
        FDataMecha GetMechaDataByInt(int index);
    }

    public class SystemMecha : AbstractSystem, ISystemMecha
    {
        private IGameModel mGameModel;
        private IModelMecha mMechaModel;
        private FDataAllMecha mMechaConfigData;

        protected override void OnInit()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMechaModel = this.GetModel<IModelMecha>();
            var storage = this.GetUtility<IStorage>();

            mMechaConfigData = storage.LoadMechaConfigData();


            for (int i = 0; i < mGameModel.MechaModels.Length; i++)
            {
                mGameModel.MechaModels[i].Value = mMechaConfigData.MechasData[i].MechaId;
            }

            this.RegisterEvent<EventGamePrepare>(e =>
            {
                this.SendEvent<EventInitMecha>();
            });

            this.RegisterEvent<EventMechaInPlacing>(e =>
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

        public FDataMecha GetMechaDataById(string id)
        {
            for (int i = 0; i < mMechaConfigData.MechasData.Length; i++)
            {
                if (id.Equals(mMechaConfigData.MechasData[i].MechaId))
                {
                    return mMechaConfigData.MechasData[i];
                }
            }
            Assert.IsTrue(false, "Mecha id " + id + " Not Found!");
            return new FDataMecha();
        }

        public FDataMecha GetMechaDataByInt(int index)
        {
            return GetMechaDataById(GetMechaIdByInt(index));
        }
    }
}
