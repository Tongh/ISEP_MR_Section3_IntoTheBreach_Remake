using UnityEngine;
using FrameworkDesign;
using OutOfTheBreach.Game;
using OutOfTheBreach.System;

namespace OutOfTheBreach.Test
{
    public class TempTestScrip : MonoBehaviour, IController
    {
        // Start is called before the first frame update
        private void Awake()
        {
            var mMapMakerSystem = this.GetSystem<IMapMakerSystem>();
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
