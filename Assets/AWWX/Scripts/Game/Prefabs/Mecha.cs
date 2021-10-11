using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class Mecha : MonoBehaviour, IController
    {
        private void OnMouseDown()
        {

        }

        public void Init(int id)
        {
            transform.localPosition = new Vector3(0, -1, 0);
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
