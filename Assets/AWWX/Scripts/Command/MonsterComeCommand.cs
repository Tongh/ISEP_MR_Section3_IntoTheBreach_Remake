using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class MonsterComeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.GamePreparing, "Monster coming must after game preparing.");
            gameModel.GameState.Value = (int)EGameState.MonsterComing;

            this.SendEvent<MonsterComeEvent>();
        }
    }
}
