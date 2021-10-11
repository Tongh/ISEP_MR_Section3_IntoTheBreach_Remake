using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class Monster : MonoBehaviour, IController
    {
        private void OnMouseDown()
        {

        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
