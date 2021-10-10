using FrameworkDesign;

namespace OutOfTheBreach
{
    public class StartGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {

            this.SendEvent<GameStartEvent>();
        }
    }
}
