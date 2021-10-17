using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IModelGround : IModel
    {
        BindableProperty<int>[,] GroundTypeMap { get; }

        // 0: no one, 1: mecha, 2: monster, 3: Building, 4: Montain
        BindableProperty<int>[,] StandingMap { get; }
    }

    public class ModelGround : AbstractModel, IModelGround
    {
        protected override void OnInit()
        {
            ResetMap();
        }

        public BindableProperty<int>[,] GroundTypeMap { get; } = new BindableProperty<int>[8, 8];
        public BindableProperty<int>[,] StandingMap { get; } = new BindableProperty<int>[8, 8];

        private void ResetMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GroundTypeMap[i, j] = new BindableProperty<int>() { Value = 0 };
                    StandingMap[i, j] = new BindableProperty<int>() { Value = 0 };
                }
            }
        }
    }
}
