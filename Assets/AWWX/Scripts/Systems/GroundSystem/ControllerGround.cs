using UnityEngine;
using FrameworkDesign;

namespace OutOfTheBreach
{
    public class ControllerGround : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private IModelGround mMapModel;
        private ISystemGround mMapMakerSystem;

        private int mGroundType;
        private int x, y;

        private void OnMouseDown()
        {
            //mGameModel.SelectingUnitId.Value = -2;
            //mGameModel.SelectingGroundType.Value = mMapModel.GroundTypeMap[x, y].Value;
        }

        public void Init(int X, int Y)
        {
            x = X;
            y = Y;

            mGameModel = this.GetModel<IGameModel>();
            mMapModel = this.GetModel<IModelGround>();
            mMapMakerSystem = this.GetSystem<ISystemGround>();

            transform.position = new Vector3(X, 0, Y);

            mMapModel.GroundTypeMap[X, Y].RegisterOnValueChanged(OnGroundChanged);

            OnGroundChanged(mMapModel.GroundTypeMap[X, Y].Value);
        }

        private void OnDestroy()
        {
            //mMapModel.GroundTypeMap[x, y].UnRegisterOnValueChanged(OnGroundChanged);
            mMapModel = null;
        }

        private void OnGroundChanged(int GroundType)
        {
            mGroundType = GroundType;
            GetComponent<MeshRenderer>().material =  mMapMakerSystem.GetMateirialByGround(GroundType);
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
