using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameSettingsPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;

        private void Start()
        {
            mGameModel = this.GetModel<IGameModel>();
            mGameModel.Difficulty.RegisterOnValueChanged(OnDifficultyChanged);

            transform.Find("TopBarPanel/BtnReturn").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(0);
                });

            transform.Find("TopBarPanel/BtnStartGame").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    this.SendCommand<CommandPrepareGame>();
                });

            transform.Find("TopBarPanel/BtnDifficulty").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    this.SendCommand<CommandSwitchDifficulty>();
                });

            OnDifficultyChanged(mGameModel.Difficulty.Value);
        }

        private void OnDestroy()
        {
            mGameModel.Difficulty.UnRegisterOnValueChanged(OnDifficultyChanged);
            mGameModel = null;
        }

        private void OnDifficultyChanged(int newValue)
        {
            transform.Find("TopBarPanel/BtnDifficulty/Text").GetComponent<Text>()
                .text = ((EGameDifficulty)newValue).ToString();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
