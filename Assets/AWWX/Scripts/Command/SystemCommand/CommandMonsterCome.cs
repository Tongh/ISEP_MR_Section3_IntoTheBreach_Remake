using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class CommandMonsterCome : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.MonsterPreparing, nameof(EGameState.MonsterComing) + " must after " + nameof(EGameState.MonsterPreparing));
            gameModel.GameState.Value = (int)EGameState.MonsterComing;

            Debug.Log("Game State Update to [" + nameof(EGameState.MonsterComing) + "]");

            this.SendEvent<EventMonsterCome>();
        }
    }
}
