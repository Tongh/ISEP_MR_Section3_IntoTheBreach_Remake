using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IMonsterSystem : ISystem
    {

    }

    public class MonsterSystem : AbstractSystem, IMonsterSystem
    {
        private MonsterConfigData mMonsterConfigData;

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            mMonsterConfigData = storage.LoadMonsterConfigData();
        }
    }
}
