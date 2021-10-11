using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class GroundNode : MonoBehaviour, IController
    {
        public GameObject GroundCubePrefab;

        private void Start()
        {
            this.RegisterEvent<InitGroundEvent>(InitGround);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<InitGroundEvent>(InitGround);
        }

        private void InitGround(InitGroundEvent e)
        {
            foreach (Transform childTrans in transform)
            {
                Destroy(childTrans.gameObject);
            }

            Assert.IsNotNull(GroundCubePrefab, nameof(GroundCubePrefab) + " Not set!");

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameObject GroundCube = Instantiate(GroundCubePrefab);
                    GroundCube.transform.parent = transform;
                    GroundCubePrefab.GetComponent<GroundCube>().Init(i, j);
                }
            }

            this.SendCommand<PrepareMonsterCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
