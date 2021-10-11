using FrameworkDesign;
using System.Collections.Generic;
using UnityEngine;

namespace OutOfTheBreach
{
    public interface IMapModel : IModel
    {
        BindableProperty<int>[,] Map { get; }
    }

    public class MapModel : AbstractModel, IMapModel
    {
        protected override void OnInit()
        {
            ResetMap();
        }

        public BindableProperty<int>[,] Map { get; } = new BindableProperty<int>[8, 8];

        private void ResetMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Map[i, j] = new BindableProperty<int>() { Value = 0 };
                }
            }
        }
    }
}
