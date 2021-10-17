using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface ISystemDummy : ISystem
    {

    }

    public class SystemDummy : AbstractSystem, ISystemDummy
    {
        private IModelDummy mModelDummy;

        protected override void OnInit()
        {
            mModelDummy = this.GetModel<IModelDummy>();
        }
    }
}
