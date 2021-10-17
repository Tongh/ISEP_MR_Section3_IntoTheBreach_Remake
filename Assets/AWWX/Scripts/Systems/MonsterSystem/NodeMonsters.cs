using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class NodeMonsters : MonoBehaviour, IController
    {
        public GameObject MonsterPrefab;

        void Start()
        {
            this.RegisterEvent<EventMonsterCome>(InitMonster);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<EventMonsterCome>(InitMonster);
        }

        private void InitMonster(EventMonsterCome e)
        {
            foreach (Transform childTrans in transform)
            {
                Destroy(childTrans.gameObject);
            }

            Assert.IsNotNull(MonsterPrefab, nameof(MonsterPrefab) + " Not set!");

            for (int i = 0; i < 10; i++)
            {
                GameObject monster = Instantiate(MonsterPrefab);
                monster.transform.parent = transform;
                monster.GetComponent<ControllerMonster>().Init(i + 3);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
