using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameNode : MonoBehaviour, IController
    {
        private void Start()
        {
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
