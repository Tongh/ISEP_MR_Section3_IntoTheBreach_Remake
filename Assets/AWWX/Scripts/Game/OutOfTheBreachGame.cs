using FrameworkDesign;

namespace OutOfTheBreach
{
    public class OutOfTheBreachGame : Architecture<OutOfTheBreachGame>
    {
        protected override void Init()
        {
            RegisterModel<IMapModel>(new MapModel());

            RegisterSystem<IMapMakerSystem>(new MapMakerSystem());
        }
    }
}
