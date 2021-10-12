using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class PrepareMonsterCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.GamePreparing, nameof(EGameState.MonsterPreparing) + " must after " + nameof(EGameState.GamePreparing));
            gameModel.GameState.Value = (int)EGameState.MonsterPreparing;

            this.SendEvent<InitMonsterEvent>();
        }
    }
}
