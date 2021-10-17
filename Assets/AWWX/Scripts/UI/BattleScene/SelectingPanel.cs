using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class SelectingPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private IModelMecha mMechaModel;
        private IModelMonster mMonsterModel;

        private ISystemGround mMapMakerSystem;

        private void Start()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMechaModel = this.GetModel<IModelMecha>();
            mMonsterModel = this.GetModel<IModelMonster>();

            mMapMakerSystem = this.GetSystem<ISystemGround>();

            mGameModel.SelectingUnitId.RegisterOnValueChanged(OnSelectingUnitIdChanged);
            mGameModel.SelectingGroundType.RegisterOnValueChanged(OnSelectingGroundTypeChanged);

            OnSelectingUnitIdChanged(-1);
        }

        private void OnDestroy()
        {
            mGameModel.SelectingUnitId.UnRegisterOnValueChanged(OnSelectingUnitIdChanged);
            mGameModel.SelectingGroundType.UnRegisterOnValueChanged(OnSelectingGroundTypeChanged);
            mGameModel = null;
        }

        private void OnSelectingUnitIdChanged(int newValue)
        {
            gameObject.SetActive(newValue != -1);
            if (newValue == -1)
            {
            }
            else if (newValue == -2) // Ground
            {
                int groundtype = mGameModel.SelectingGroundType.Value;
                OnSelectingGroundTypeChanged(groundtype);
            }
            else if (newValue < 3) // Mecha
            {
                //transform.Find("Name").GetComponent<Text>()
                //    .text = mMechaModel.Mechas[newValue].NickName.Value;
            }
            else if (newValue < 13) // Monster
            {
                newValue -= 3;
                FDataMonster data = mMonsterModel.Monsters[newValue].monsterData;

                transform.Find("Name").GetComponent<Text>()
                    .text = data.MonsterId;
                transform.Find("Description").GetComponent<Text>()
                    .text = data.Description;
                transform.Find("Life").GetComponent<Text>()
                    .text = "Life: " + mMonsterModel.Monsters[newValue].Life.Value + " / " + mMonsterModel.Monsters[newValue].MaxLife.Value;
                transform.Find("Speed").GetComponent<Text>()
                    .text = "Speed: " + mMonsterModel.Monsters[newValue].Speed.Value;
                transform.Find("Flying").GetComponent<Text>()
                    .text = mMonsterModel.Monsters[newValue].bIsFlying.Value ? 
                    "Flying Unit" : "Land Unit";

            }
        }

        private void OnSelectingGroundTypeChanged(int newValue)
        {
            if (mGameModel.SelectingUnitId.Value == -2)
            {
                FDataMapGround data = mMapMakerSystem.GetMapGroundConfigDataByGroundTypeInt(newValue);

                transform.Find("Name").GetComponent<Text>()
                    .text = data.GroundName;
                transform.Find("Description").GetComponent<Text>()
                    .text = data.Description;
                transform.Find("Speed").GetComponent<Text>()
                    .text = "";
                transform.Find("Flying").GetComponent<Text>()
                    .text = "";

                //string str = data.GroundType == EMapGroundType.Mountain ? "Life: " + mMapMakerSystem. + " / 2";
                transform.Find("Life").GetComponent<Text>()
                    .text = "";
            }
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
