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
            RegisterModel<IModelMonster>(new ModelMonster());
            RegisterModel<IModelDummy>(new ModelDummy());

            RegisterSystem<ISystemGround>(new SystemGround());
            RegisterSystem<ISystemMecha>(new SystemMecha());
            RegisterSystem<ISystemMonster>(new SystemMonster());
            RegisterSystem<ISystemMouse>(new SystemMouse());
            RegisterSystem<ISystemDummy>(new SystemDummy());
            RegisterSystem<ISystemTurn>(new SystemTurn());
            RegisterSystem<ISystemAbility>(new SystemAbility());

            RegisterUtility<IStorage>(new StorageJson());
        }
    }
}
