using FrameworkDesign;
using UnityEngine;
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
        void NextPlacingMecha();
    }

    public class SystemMecha : AbstractSystem, ISystemMecha
    {
        private IGameModel mGameModel;
        private IModelMecha mMechaModel;
        private FDataAllMecha mMechaConfigData;

        private int MechasWaitingForPlacing = 0;

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
                NextPlacingMecha();
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

        public void NextPlacingMecha()
        {
            if (MechasWaitingForPlacing != 0)
            {
                mMechaModel.Mechas[MechasWaitingForPlacing - 1].bIsInPlacing.Value = false;
                if (MechasWaitingForPlacing == 3)
                {
                    Assert.IsTrue(mGameModel.GameState.Value == (int)EGameState.MechaInPlacing, nameof(EGameState.Gameing) + " must after " + nameof(EGameState.MechaInPlacing));
                    mGameModel.GameState.Value = (int)EGameState.Gameing;

                    Debug.Log("Game State Update to [" + nameof(EGameState.Gameing) + "]");

                    this.SendEvent<EventGameBegin>();
                }
            }
            if (MechasWaitingForPlacing != 3)
            {
                mMechaModel.Mechas[MechasWaitingForPlacing].bIsInPlacing.Value = true;
                MechasWaitingForPlacing++;
            }

        }
    }
}
