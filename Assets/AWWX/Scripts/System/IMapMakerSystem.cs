using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach
{
    public interface IMapMakerSystem : ISystem
    {
    }

    public class MapMakerSystem : AbstractSystem, IMapMakerSystem
    {
        private IMapModel mMapModel;

        protected override void OnInit()
        {
            Debug.Log("Map Maker System Loaded");

            mMapModel = this.GetModel<IMapModel>();

            this.RegisterEvent<GamePrepareEvent>(e =>
            {
                RandomMap();
            });
        }

        public void RandomMap()
        {
            RandomGroundType();

            //this.SendEvent<>();
        }

        private void RandomGroundType()
        {
            int[] prob = new int[] { 80, 5, 5, 5, 5 };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mMapModel.Map[i, j].Value == 0)
                    {
                        mMapModel.Map[i, j].Value = RandomLibrary.randAdd(prob, 100);
                    }
                }
            }
        }
    }
}
