using UnityEngine;
using FrameworkDesign;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class MonstersNode : MonoBehaviour, IController
    {
        public GameObject MonsterPrefab;

        void Start()
        {
            this.RegisterEvent<MonsterComeEvent>(InitMonster);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<MonsterComeEvent>(InitMonster);
        }


        private void InitMonster(MonsterComeEvent e)
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
                MonsterPrefab.GetComponent<Monster>().Init(i + 3);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
