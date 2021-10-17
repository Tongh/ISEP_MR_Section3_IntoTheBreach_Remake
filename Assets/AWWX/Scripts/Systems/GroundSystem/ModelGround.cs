using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IModelGround : IModel
    {
        BindableProperty<int>[,] GroundTypeMap { get; }
        BindableProperty<bool>[,] bIsSomeoneHereMap { get; }
    }

    public class ModelGround : AbstractModel, IModelGround
    {
        protected override void OnInit()
        {
            ResetMap();
        }

        public BindableProperty<int>[,] GroundTypeMap { get; } = new BindableProperty<int>[8, 8];
        public BindableProperty<bool>[,] bIsSomeoneHereMap { get; } = new BindableProperty<bool>[8, 8];

        private void ResetMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GroundTypeMap[i, j] = new BindableProperty<int>() { Value = 0 };
                    bIsSomeoneHereMap[i, j] = new BindableProperty<bool>() { Value = false };
                }
            }
        }
    }
}
