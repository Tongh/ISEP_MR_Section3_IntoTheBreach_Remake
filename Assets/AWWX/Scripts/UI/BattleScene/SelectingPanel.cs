using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class SelectingPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private IMechaModel mMechaModel;
        private IMonsterModel mMonsterModel;

        private IMapMakerSystem mMapMakerSystem;

        private void Start()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMechaModel = this.GetModel<IMechaModel>();
            mMonsterModel = this.GetModel<IMonsterModel>();


            mMapMakerSystem = this.GetSystem<IMapMakerSystem>();

            mGameModel.SelectingUnitId.RegisterOnValueChanged(OnSelectingUnitIdChanged);

            OnSelectingUnitIdChanged(-1);
        }

        private void OnDestroy()
        {
            mGameModel.SelectingUnitId.UnRegisterOnValueChanged(OnSelectingUnitIdChanged);
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
                MapGroundConfigData data = mMapMakerSystem.GetMapGroundConfigDataByGroundTypeInt(groundtype);

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
            else if (newValue < 3) // Mecha
            {
                //transform.Find("Name").GetComponent<Text>()
                //    .text = mMechaModel.Mechas[newValue].NickName.Value;
            }
            else if (newValue < 13) // Monster
            {
                newValue -= 3;
                MonsterData data = mMonsterModel.Monsters[newValue].monsterData;

                transform.Find("Name").GetComponent<Text>()
                    .text = data.MonsterId;
                transform.Find("Description").GetComponent<Text>()
                    .text = data.Description;
                transform.Find("Life").GetComponent<Text>()
                    .text = "Life: " + mMonsterModel.Monsters[newValue].Life.Value + " / " + data.Life;
                transform.Find("Speed").GetComponent<Text>()
                    .text = "Speed: " + mMonsterModel.Monsters[newValue].Speed.Value;
                transform.Find("Flying").GetComponent<Text>()
                    .text = mMonsterModel.Monsters[newValue].bIsFlying.Value ? 
                    "Flying Unit" : "Land Unit";

            }
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
