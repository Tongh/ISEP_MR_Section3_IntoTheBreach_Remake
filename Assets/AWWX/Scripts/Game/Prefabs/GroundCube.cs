using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class GroundCube : MonoBehaviour, IController
    {
        private IMapModel mMapModel;
        private IMapMakerSystem mMapMakerSystem;

        public void Init(int X, int Y)
        {
            mMapModel = this.GetModel<IMapModel>();
            mMapMakerSystem = this.GetSystem<IMapMakerSystem>();

            transform.position = new Vector3(X, 0, Y);

            mMapModel.GroundTypeMap[X, Y].RegisterOnValueChanged(OnGroundChanged);

            OnGroundChanged(mMapModel.GroundTypeMap[X, Y].Value);
        }

        private void OnGroundChanged(int GroundType)
        {
            GetComponent<MeshRenderer>().material =  mMapMakerSystem.GetMateirialByGround(GroundType);
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
