using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class MechasNode : MonoBehaviour, IController
    {
        public GameObject MechaPrefab;

        void Start()
        {
            this.RegisterEvent<InitMechaEvent>(InitMecha);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<InitMechaEvent>(InitMecha);
        }

        private void InitMecha(InitMechaEvent e)
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
                MechaPrefab.GetComponent<Mecha>().Init(i);
            }

            this.SendCommand<WaitMechaInPlaceCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
