using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class NodeMechas : MonoBehaviour, IController
    {
        private IGameModel mGameModel;

        public GameObject MechaPrefab;

        void Start()
        {
            mGameModel = this.GetModel<IGameModel>();

            this.RegisterEvent<EventInitMecha>(InitMecha);
        }

        private void Update()
        {
            if (
                mGameModel.GameState.Value == (int)EGameState.MechaInPlacing && 
                Input.GetMouseButtonDown(0))
            {
                this.SendCommand<CommandShootMecha>();
            }
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<EventInitMecha>(InitMecha);
        }

        private void InitMecha(EventInitMecha e)
        {
            Assert.IsNotNull(MechaPrefab, nameof(MechaPrefab) + " Not set!");

            this.SendCommand<CommandWaitMechaInPlace>();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
