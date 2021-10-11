using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GroundCube : MonoBehaviour, IController
    {
        private IMapMakerSystem mapMakerSystem;

        public void Init(int X, int Y)
        {
            transform.position = new Vector3(X, 0, Y);

            var mapModel = this.GetModel<IMapModel>();
            mapMakerSystem = this.GetSystem<IMapMakerSystem>();

            mapModel.GroundTypeMap[X, Y].RegisterOnValueChanged(OnGroundChanged);

            OnGroundChanged(mapModel.GroundTypeMap[X, Y].Value);
        }

        private void OnGroundChanged(int GroundType)
        {
            GetComponent<MeshRenderer>().material =  mapMakerSystem.GetMateirialByGround(GroundType);
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
