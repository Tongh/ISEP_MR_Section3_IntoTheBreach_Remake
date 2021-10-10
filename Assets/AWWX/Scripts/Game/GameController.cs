using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameController : MonoBehaviour, IController
    {
        public GameObject GroundCubePrefab;

        // Start is called before the first frame update
        private void Start()
        {
            this.RegisterEvent<GamePrepareEvent>(OnGameEnter);
            this.RegisterEvent<GameStartEvent>(OnGameStart);

            this.SendCommand<PrepareGameCommand>();
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GamePrepareEvent>(OnGameEnter);
            this.UnRegisterEvent<GameStartEvent>(OnGameStart);
        }

        private void OnGameEnter(GamePrepareEvent e)
        {
            var GroundRoot = transform.Find("Ground");

            foreach (Transform childTrans in GroundRoot)
            {
                Destroy(childTrans.gameObject);
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameObject GroundCube = Instantiate(GroundCubePrefab);
                    GroundCube.transform.parent = GroundRoot;
                    GroundCubePrefab.GetComponent<GroundCube>().Init(i, j);
                }
            }
        }

        private void OnGameStart(GameStartEvent e)
        {
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
