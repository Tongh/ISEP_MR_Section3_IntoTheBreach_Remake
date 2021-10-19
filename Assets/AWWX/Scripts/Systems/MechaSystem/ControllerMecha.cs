using UnityEngine;
using FrameworkDesign;
using System.Collections;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class ControllerMecha : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private IModelMecha mModelMecha;
        private ISystemMouse mSystemMouse;
        private ISystemMecha mSystemMecha;
        private ISystemGround mSystemGround;

        public int id;
        private Vector3 TargetLocation;
        private Coroutine CoroutineFollowCursorMove = null;
        private Coroutine CoroutineEjection = null;

        private void Start()
        {
            mGameModel = this.GetModel<IGameModel>();
            mModelMecha = this.GetModel<IModelMecha>();
            mSystemMouse = this.GetSystem<ISystemMouse>();
            mSystemMecha = this.GetSystem<ISystemMecha>();
            mSystemGround = this.GetSystem<ISystemGround>();

            FDataMecha mechaData = mSystemMecha.GetMechaDataByInt(id);

            mModelMecha.Mechas[id].mechaData = mechaData;

            mModelMecha.Mechas[id].bIsInPlacing.RegisterOnValueChanged(OnbIsInPlacingChanged);
        }

        private void OnDestroy()
        {
            mModelMecha.Mechas[id].bIsInPlacing.UnRegisterOnValueChanged(OnbIsInPlacingChanged);
            mModelMecha = null;
        }

        private void Update()
        {
        }

        private void OnMouseDown()
        {
            Assert.IsNotNull(mGameModel, "Click too early!");
            mGameModel.SelectingUnitId.Value = id;
        }

        private IEnumerator Eject()
        {
            transform.position = TargetLocation + Vector3.up * 8.8f;
            yield return new WaitForEndOfFrame();
            while (true)
            {
                transform.position = Vector3.Lerp(transform.position, TargetLocation, Time.deltaTime * 5f);

                if (Mathf.Approximately(transform.position.x, TargetLocation.x) &&
                    Mathf.Approximately(transform.position.y, TargetLocation.y) &&
                    Mathf.Approximately(transform.position.z, TargetLocation.z)
                    )
                {
                    StopEjecting();
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private void StopEjecting()
        {
            if (CoroutineEjection == null) return;
            StopCoroutine(CoroutineEjection);
            CoroutineEjection = null;
        }

        private IEnumerator FollowCursorMove()
        {
            while (true)
            {
                Vector2Int Loc2 = mSystemMouse.MapLocation2;
                if (mSystemGround.IsLocationValidForStanding(Loc2))
                {
                    TargetLocation.x = Loc2.x;
                    TargetLocation.z = Loc2.y;
                }
                transform.position = TargetLocation;
                yield return new WaitForEndOfFrame();
            }
        }

        private void StopFollowCursorMove()
        {
            if (CoroutineFollowCursorMove == null) return;
            StopCoroutine(CoroutineFollowCursorMove);
            CoroutineFollowCursorMove = null;
        }

        private void OnbIsInPlacingChanged(bool newValue)
        {
            TargetLocation.y = 1.2f;

            if (newValue)
            {
                if (CoroutineFollowCursorMove == null)
                {
                    CoroutineFollowCursorMove = StartCoroutine(FollowCursorMove());
                }
            }
            else
            {
                StopFollowCursorMove();
                if (CoroutineEjection == null)
                {
                    CoroutineEjection = StartCoroutine(Eject());

                    var mSystemGround = this.GetSystem<ISystemGround>();
                    mSystemGround.EntityStandingChanged((int)transform.position.x, (int)transform.position.z, 1);
                }
            }
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
