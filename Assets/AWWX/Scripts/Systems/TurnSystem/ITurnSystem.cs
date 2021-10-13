using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface ITurnSystem : ISystem
    {

    }

    public class TurnSystem : AbstractSystem, ITurnSystem
    {

        protected override void OnInit()
        {

        }
    }
}
