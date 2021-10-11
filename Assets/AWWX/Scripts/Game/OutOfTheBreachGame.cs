using FrameworkDesign;

namespace OutOfTheBreach
{
    public class OutOfTheBreachGame : Architecture<OutOfTheBreachGame>
    {
        protected override void Init()
        {
            RegisterModel<IGameModel>(new GameModel());
            RegisterModel<IMechaModel>(new MechaModel());
            RegisterModel<IMonsterModel>(new MonsterModel());
            RegisterModel<IMapModel>(new MapModel());

            RegisterSystem<IMechaSystem>(new MechaSystem());
            RegisterSystem<IMapMakerSystem>(new MapMakerSystem());
            RegisterSystem<IMonsterSystem>(new MonsterSystem());
            //RegisterSystem<ITurnSystem>(new TurnSystem());

            RegisterUtility<IStorage>(new JsonStorage());
        }
    }
}
