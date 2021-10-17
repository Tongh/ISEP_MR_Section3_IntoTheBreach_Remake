using FrameworkDesign;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace OutOfTheBreach
{
    public class CommandShootMecha : AbstractCommand
    {
        protected override void OnExecute()
        {
            var system = this.GetSystem<ISystemMecha>();
            system.NextPlacingMecha();
        }
    }
}
