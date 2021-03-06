using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class CommandWaitMechaInPlace : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.MonsterComing, nameof(EGameState.MechaInPlacing) + " must after " + nameof(EGameState.MonsterComing));
            gameModel.GameState.Value = (int)EGameState.MechaInPlacing;

            Debug.Log("Game State Update to [" + nameof(EGameState.MechaInPlacing) + "]");

            this.SendEvent<EventMechaInPlacing>(new EventMechaInPlacing()
            {
                MechaIndex = 0
            });
        }
    }
}
