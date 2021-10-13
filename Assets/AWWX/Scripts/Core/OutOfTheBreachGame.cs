using FrameworkDesign;

namespace OutOfTheBreach
{
    public class OutOfTheBreachGame : Architecture<OutOfTheBreachGame>
    {
        protected override void Init()
        {
            RegisterModel<IGameModel>(new GameModel());
            RegisterModel<IModelGround>(new ModelGround());
            RegisterModel<IModelMecha>(new ModelMecha());
            RegisterModel<IMonsterModel>(new MonsterModel());

            RegisterSystem<ISystemGround>(new SystemGround());
            RegisterSystem<ISystemMecha>(new SystemMecha());
            RegisterSystem<IMonsterSystem>(new MonsterSystem());
            //RegisterSystem<ITurnSystem>(new TurnSystem());

            RegisterUtility<IStorage>(new JsonStorage());
        }
    }
}
