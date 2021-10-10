using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IMechaSystem : ISystem
    {

    }

    public class MechaSystem : AbstractSystem, IMechaSystem
    {
        protected override void OnInit()
        {

        }
    }
}
