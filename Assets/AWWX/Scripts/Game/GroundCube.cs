using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GroundCube : MonoBehaviour, IController
    {
        public void Init(int X, int Y)
        {
            transform.position = new Vector3(X, 0, Y);
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
