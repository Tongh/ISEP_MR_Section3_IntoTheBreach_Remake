using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class WaitMechaInPlaceCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.MonsterComing, nameof(EGameState.MonsterComing) + " must after " + nameof(EGameState.MechaInPlacing));
            gameModel.GameState.Value = (int)EGameState.MechaInPlacing;

            this.SendEvent<MechaInPlacingEvent>();
        }
    }
}
