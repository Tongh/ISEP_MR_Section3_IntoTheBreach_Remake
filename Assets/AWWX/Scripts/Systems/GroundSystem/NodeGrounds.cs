using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class NodeGrounds : MonoBehaviour, IController
    {
        public GameObject GroundCubePrefab;

        private void Start()
        {
            this.RegisterEvent<EventInitGround>(InitGround);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<EventInitGround>(InitGround);
        }

        private void InitGround(EventInitGround e)
        {
            Assert.IsNotNull(GroundCubePrefab, nameof(GroundCubePrefab) + " Not set!");

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        GameObject Ground = Instantiate(GroundCubePrefab);
            //        Ground.transform.parent = transform;
            //        GroundCubePrefab.GetComponent<ControllerGround>().Init(i, j);
            //    }
            //}

            this.SendCommand<CommandPrepareMonster>();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
