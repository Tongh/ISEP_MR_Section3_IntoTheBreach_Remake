using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public class CommandPrepareGame : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.GameState.Value = (int)EGameState.GamePreparing;

            Debug.Log("Game State Update to [" + nameof(EGameState.GamePreparing) + "]");

            this.SendEvent<EventGamePrepare>();
        }
    }
}
