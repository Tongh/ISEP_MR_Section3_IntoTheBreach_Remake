using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class CommandPrepareMonster : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            Assert.IsTrue(gameModel.GameState.Value == (int)EGameState.GamePreparing, nameof(EGameState.MonsterPreparing) + " must after " + nameof(EGameState.GamePreparing));
            gameModel.GameState.Value = (int)EGameState.MonsterPreparing;

            Debug.Log("Game State Update to [" + nameof(EGameState.MonsterPreparing) + "]");

            this.SendEvent<EventInitMonster>();
        }
    }
}
