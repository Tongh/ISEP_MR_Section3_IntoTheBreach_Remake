using FrameworkDesign;

namespace OutOfTheBreach
{
    public class PrepareGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {

            this.SendEvent<GamePrepareEvent>();
        }
    }
}
