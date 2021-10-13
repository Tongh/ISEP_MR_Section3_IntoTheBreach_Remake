using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IModelMecha : IModel
    {
        FDataMecha [] Mechas { get; }
    }

    public class ModelMecha : AbstractModel, IModelMecha
    {
        protected override void OnInit()
        {
            ResetArray();
        }

        public FDataMecha [] Mechas { get; } = new FDataMecha[3];

        private void ResetArray()
        {
            for (int i = 0; i < 3; i++)
            {
                Mechas[i] = new FDataMecha(i);
            }
        }
    }
}
