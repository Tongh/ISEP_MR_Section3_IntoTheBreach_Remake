using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IModelMecha : IModel
    {
        FPropertyMecha [] Mechas { get; }
    }

    public class ModelMecha : AbstractModel, IModelMecha
    {
        protected override void OnInit()
        {
            ResetArray();
        }

        public FPropertyMecha [] Mechas { get; } = new FPropertyMecha[3];

        private void ResetArray()
        {
            for (int i = 0; i < 3; i++)
            {
                Mechas[i] = new FPropertyMecha(i);
            }
        }
    }
}
