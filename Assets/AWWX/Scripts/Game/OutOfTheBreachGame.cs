using FrameworkDesign;
using OutOfTheBreach.System;
using OutOfTheBreach.Model;

namespace OutOfTheBreach.Game
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
