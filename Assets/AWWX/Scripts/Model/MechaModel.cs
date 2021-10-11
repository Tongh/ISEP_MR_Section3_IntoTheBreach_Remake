using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IMechaModel : IModel
    {
        BindableMechaData [] Mechas { get; }
    }

    public class MechaModel : AbstractModel, IMechaModel
    {
        protected override void OnInit()
        {
            ResetArray();
        }

        public BindableMechaData [] Mechas { get; } = new BindableMechaData[3];

        private void ResetArray()
        {
            for (int i = 0; i < 3; i++)
            {
                Mechas[i] = new BindableMechaData(i);
            }
        }
    }
}
