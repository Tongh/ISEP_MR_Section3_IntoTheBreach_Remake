using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IModelMonster : IModel
    {
        FPropertyMonster [] Monsters { get; }
    }

    public class ModelMonster : AbstractModel, IModelMonster
    {
        protected override void OnInit()
        {
            ResetArray();
        }

        public FPropertyMonster [] Monsters { get; } = new FPropertyMonster[10];

        private void ResetArray()
        {
            for (int i = 0; i < 10; i++)
            {
                Monsters[i] = new FPropertyMonster(i + 3);
            }
        }
    }
}
