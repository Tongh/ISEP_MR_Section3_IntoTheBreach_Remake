using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IMonsterModel : IModel
    {
        BindableMonsterData [] Monsters { get; }
    }

    public class MonsterModel : AbstractModel, IMonsterModel
    {
        protected override void OnInit()
        {
            ResetArray();
        }

        public BindableMonsterData [] Monsters { get; } = new BindableMonsterData[10];

        private void ResetArray()
        {
            for (int i = 0; i < 10; i++)
            {
                Monsters[i] = new BindableMonsterData((i+3).ToString());
            }
        }
    }
}
