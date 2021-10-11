using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class UI : MonoBehaviour, IController
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnDestroy()
        {
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
