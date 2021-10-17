using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class NodeMechas : MonoBehaviour, IController
    {
        public GameObject MechaPrefab;

        void Start()
        {
            this.RegisterEvent<EventInitMecha>(InitMecha);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<EventInitMecha>(InitMecha);
        }

        private void InitMecha(EventInitMecha e)
        {
            foreach (Transform childTrans in transform)
            {
                Destroy(childTrans.gameObject);
            }

            Assert.IsNotNull(MechaPrefab, nameof(MechaPrefab) + " Not set!");

            for (int i = 0; i < 3; i++)
            {
                GameObject mecha = Instantiate(MechaPrefab);
                mecha.transform.parent = transform;
                MechaPrefab.GetComponent<ControllerMecha>().Init(i);
            }

            this.SendCommand<CommandWaitMechaInPlace>();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
