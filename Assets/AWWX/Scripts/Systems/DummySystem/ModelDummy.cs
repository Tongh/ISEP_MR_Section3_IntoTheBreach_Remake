using FrameworkDesign;
using System.Collections.Generic;

namespace OutOfTheBreach
{
    public interface IModelDummy : IModel
    {
        List<FPropertyDummy> Demmies { get; }
    }

    public class ModelDummy : AbstractModel, IModelDummy
    {
        protected override void OnInit()
        {
        }

        public List<FPropertyDummy> Demmies { get; } = new List<FPropertyDummy>();
    }
}
