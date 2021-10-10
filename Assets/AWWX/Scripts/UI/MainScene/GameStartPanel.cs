using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BtnsPanel/BtnNewGame").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(1);
                });

            transform.Find("BtnsPanel/BtnQuit").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                });
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
