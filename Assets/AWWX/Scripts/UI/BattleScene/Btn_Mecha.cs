using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class Btn_Mecha : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private ISystemMecha mMechaSystem;

        public int MechaNumber = 0;

        // Start is called before the first frame update
        private void Start()
        {
            mGameModel = this.GetModel<IGameModel>();
            mMechaSystem = this.GetSystem<ISystemMecha>();

            mGameModel.MechaModels[MechaNumber].RegisterOnValueChanged(OnMechaModelChanged);
            OnMechaModelChanged(mGameModel.MechaModels[MechaNumber].Value);

            switch (MechaNumber)
            {
                case 0:
                    transform.GetComponent<Button>()
                        .onClick.AddListener(() =>
                        {
                            this.SendCommand<SwitchMecha_1Command>();
                        });
                    break;
                case 1:
                    transform.GetComponent<Button>()
                        .onClick.AddListener(() =>
                        {
                            this.SendCommand<SwitchMecha_2Command>();
                        });
                    break;
                case 2:
                    transform.GetComponent<Button>()
                        .onClick.AddListener(() =>
                        {
                            this.SendCommand<SwitchMecha_3Command>();
                        });
                    break;
            }
        }

        private void OnDestroy()
        {
            mGameModel.MechaModels[MechaNumber].UnRegisterOnValueChanged(OnMechaModelChanged);
            mGameModel = null;
        }

        private void OnMechaModelChanged(string newValue)
        {
            MechaData data = mMechaSystem.GetMechaDataById(newValue);

            var tex = GameplayLibrary.GetMechaPreviewTex(newValue);
            transform.Find("Panel/RawImage").GetComponent<RawImage>()
                .texture = tex;

            transform.Find("Panel/Name").GetComponent<Text>()
                .text = newValue;
            transform.Find("Panel/Life").GetComponent<Text>()
                .text = "Life: " + data.Life;
            transform.Find("Panel/Speed").GetComponent<Text>()
                .text = "Speed: " + data.Speed;
            transform.Find("Panel/Description").GetComponent<Text>()
                .text = data.Description;
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
