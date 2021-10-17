using FrameworkDesign;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public interface ISystemMouse : ISystem
    {
        Vector2Int MapLocation2 { get; }
    }

    public class SystemMouse : AbstractSystem, ISystemMouse
    {
        private Vector2Int LastLocation2;

        protected override void OnInit()
        {

        }

        public Vector2Int MapLocation2 => GetMapLocation2();

        private Vector2Int GetMapLocation2()
        {
            Vector2Int ret = Vector2Int.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                ret.x = Mathf.Clamp((int)hitInfo.point.x, 0, 7);
                ret.y = Mathf.Clamp((int)hitInfo.point.z, 0, 7);
                LastLocation2 = ret;
            }
            else
            {
                ret = LastLocation2;
            }

            return ret;
        }
    }
}
