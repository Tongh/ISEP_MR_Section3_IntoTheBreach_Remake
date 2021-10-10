using FrameworkDesign;
using UnityEngine;

namespace OutOfTheBreach.System
{
    public interface IMapMakerSystem : ISystem
    {
    }

    public class MapMakerSystem : AbstractSystem, IMapMakerSystem
    {
        public int[,] map;

        protected override void OnInit()
        {
            Debug.Log("Map Maker System Loaded");
            RandomMap();
        }

        public int[,] RandomMap()
        {
            map = new int[8, 8];

            int i, j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    //Debug.Log("map[{" + i + "},{" + j + "}] = {" + map[i, j] + "}");
                }
            }

            return map;
        }

        private int[,] RandomMountain()
        {
            int[,] mountain = new int[8, 8];


            int i, j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (map[i, j] == 0)
                    {
                        //Random.
                    }
                }
            }

            return mountain;
        }
    }
}
