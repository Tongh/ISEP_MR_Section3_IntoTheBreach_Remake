using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GameNode : MonoBehaviour, IController
    {
        private void Start()
        {
        }

        private void Update()
        {
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
