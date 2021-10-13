using FrameworkDesign;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace OutOfTheBreach
{
    public class SwitchMecha_3Command : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();
            var mechaSystem = this.GetSystem<ISystemMecha>();

            List<int> indexs = Enumerable.Range(0, mechaSystem.GetMechasNum()).ToArray().ToList();

            for (int i = 0; i < gameModel.MechaModels.Length; i++)
            {
                indexs.Remove(mechaSystem.GetMechaindexById(gameModel.MechaModels[i].Value));
            }

            int randomindex = indexs[Random.Range(0, indexs.Count)];
            gameModel.MechaModels[2].Value = mechaSystem.GetMechaIdByInt(randomindex);
        }
    }
}
