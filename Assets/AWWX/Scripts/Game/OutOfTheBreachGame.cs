using FrameworkDesign;

namespace OutOfTheBreach
{
    public class OutOfTheBreachGame : Architecture<OutOfTheBreachGame>
    {
        protected override void Init()
        {
            RegisterModel<IGameModel>(new GameModel());
            RegisterModel<IMapModel>(new MapModel());

            RegisterSystem<IMapMakerSystem>(new MapMakerSystem());
            RegisterSystem<IMechaSystem>(new MechaSystem());
            RegisterSystem<IMonsterSystem>(new MonsterSystem());

            RegisterUtility<IStorage>(new JsonStorage());
        }
    }
}
