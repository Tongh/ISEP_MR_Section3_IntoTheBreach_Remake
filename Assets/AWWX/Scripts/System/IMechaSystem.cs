using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IMechaSystem : ISystem
    {

    }

    public class MechaSystem : AbstractSystem, IMechaSystem
    {
        private MechaConfigData mMechaConfigData;

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            mMechaConfigData = storage.LoadMechaConfigData();

            this.RegisterEvent<GamePrepareEvent>(e =>
            {
                InitMechasOutOfScreen();

                this.SendEvent<InitMechaEvent>();
            });
        }

        private void InitMechasOutOfScreen()
        {

        }
    }
}
