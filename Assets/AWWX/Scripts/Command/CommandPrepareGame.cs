using FrameworkDesign;

namespace OutOfTheBreach
{
    public class CommandPrepareGame : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.GameState.Value = (int)EGameState.GamePreparing;

            this.SendEvent<EventGamePrepare>();
        }
    }
}
