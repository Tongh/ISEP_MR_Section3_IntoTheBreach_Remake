using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameInfoPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;

        private void Start()
        {
            mGameModel = this.GetModel<IGameModel>();
            mGameModel.Energy.RegisterOnValueChanged(OnEnergyChanged);
            mGameModel.TurnLeft.RegisterOnValueChanged(OnTurnLeftChanged);

            OnEnergyChanged(mGameModel.Energy.Value);
            OnTurnLeftChanged(mGameModel.TurnLeft.Value);
        }

        private void OnDestroy()
        {
            mGameModel.Energy.UnRegisterOnValueChanged(OnEnergyChanged);
            mGameModel.TurnLeft.UnRegisterOnValueChanged(OnTurnLeftChanged);
            mGameModel = null;
        }

        private void OnEnergyChanged(int newValue)
        {
            transform.Find("EnergyText").GetComponent<Text>()
                .text = "Energy: " + newValue;
        }

        private void OnTurnLeftChanged(int newValue)
        {
            transform.Find("TurnLeftText").GetComponent<Text>()
                .text = "Turn Left: " + newValue;
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
