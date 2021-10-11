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

        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
