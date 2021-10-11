using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameSettingsPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;

        // Start is called before the first frame update
        void Start()
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

                    this.SendCommand<PrepareGameCommand>();
                });

            transform.Find("TopBarPanel/BtnDifficulty").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    this.SendCommand<SwitchDifficultyCommand>();
                });

            OnDifficultyChanged(mGameModel.Difficulty.Value);
        }

        private void OnDifficultyChanged(int newValue)
        {
            transform.Find("TopBarPanel/BtnDifficulty/Text").GetComponent<Text>()
                .text = ((EGameDifficulty)newValue).ToString();
        }

        private void OnDestroy()
        {
            mGameModel.Difficulty.UnReigsterOnValueChanged(OnDifficultyChanged);
            mGameModel = null;
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
