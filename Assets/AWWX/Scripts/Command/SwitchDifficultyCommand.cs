using FrameworkDesign;

namespace OutOfTheBreach
{
    public class SwitchDifficultyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.Difficulty.Value = (gameModel.Difficulty.Value + 1) % ((int)EGameDifficulty.HARD + 1);
        }
    }
}
