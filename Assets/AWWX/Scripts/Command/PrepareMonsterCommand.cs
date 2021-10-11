using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class PrepareMonsterCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.GamePreparing, "Monster Preparing must after game preparing.");
            gameModel.GameState.Value = (int)EGameState.MonsterPreparing;

            this.SendEvent<InitMonsterEvent>();
        }
    }
}
