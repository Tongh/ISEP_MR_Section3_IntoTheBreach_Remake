using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface ISystemTurn : ISystem
    {

    }

    public class SystemTurn : AbstractSystem, ISystemTurn
    {

        protected override void OnInit()
        {

        }
    }
}
