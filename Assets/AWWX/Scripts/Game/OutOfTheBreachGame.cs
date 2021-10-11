using FrameworkDesign;

namespace OutOfTheBreach
{
    public class OutOfTheBreachGame : Architecture<OutOfTheBreachGame>
    {
        protected override void Init()
        {
            RegisterModel<IGameModel>(new GameModel());
            RegisterModel<IMapModel>(new MapModel());
            RegisterModel<IMechaModel>(new MechaModel());
            RegisterModel<IMonsterModel>(new MonsterModel());

            RegisterSystem<IMapMakerSystem>(new MapMakerSystem());
            RegisterSystem<IMechaSystem>(new MechaSystem());
            RegisterSystem<IMonsterSystem>(new MonsterSystem());
            //RegisterSystem<ITurnSystem>(new TurnSystem());

            RegisterUtility<IStorage>(new JsonStorage());
        }
    }
}
