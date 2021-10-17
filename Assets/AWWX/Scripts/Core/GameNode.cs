using UnityEngine;
using FrameworkDesign;
using System.Collections;

namespace OutOfTheBreach
{
    public class GameNode : MonoBehaviour, IController
    {
        private ISystemTurn mSystemTurn;

        private void Start()
        {
            mSystemTurn = this.GetSystem<ISystemTurn>();

            this.RegisterEvent<EventGameBegin>(OnGameBegin);
        }

        private void Update()
        {
        }

        private void OnGameBegin(EventGameBegin e)
        {
            StartCoroutine(Wait2SecondsForShow());
        }

        private IEnumerator Wait2SecondsForShow()
        {
            yield return new WaitForSeconds(3f);
            mSystemTurn.NextPhase();
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
