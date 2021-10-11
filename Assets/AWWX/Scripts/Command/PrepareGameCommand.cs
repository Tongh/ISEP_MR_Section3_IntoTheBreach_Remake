using FrameworkDesign;

namespace OutOfTheBreach
{
    public class PrepareGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.GameState.Value = (int)EGameState.GamePreparing;

            this.SendEvent<GamePrepareEvent>();
        }
    }
}
