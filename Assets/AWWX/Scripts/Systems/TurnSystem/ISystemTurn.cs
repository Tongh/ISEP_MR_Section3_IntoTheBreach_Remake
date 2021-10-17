using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface ISystemTurn : ISystem
    {

    }

    public class SystemTurn : AbstractSystem, ISystemTurn
    {
        private IGameModel mGameModel;

        protected override void OnInit()
        {
            mGameModel = this.GetModel<IGameModel>();

            this.RegisterEvent<EventGameBegin>(e =>
            {
                NextPhase();
            });
        }

        private void NextPhase()
        {
            mGameModel.TurnPhase.Value++;
        }
    }
}
