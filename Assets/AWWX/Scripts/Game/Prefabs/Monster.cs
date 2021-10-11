using UnityEngine;
using FrameworkDesign;
using System.Collections;

namespace OutOfTheBreach
{
    public class Monster : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private IMonsterModel mMonsterModel;
        private IMonsterSystem mMonsterSystem;

        private int Id;
        private Vector3 NextLocation;
        private Coroutine MoveCorotine = null;

        private void OnMouseDown()
        {
            mGameModel.SelectingUnitId.Value = Id;
        }

        public void Init(int id)
        {
            this.Id = id;
            mGameModel = this.GetModel<IGameModel>();
            mMonsterModel = this.GetModel<IMonsterModel>();
            mMonsterSystem = this.GetSystem<IMonsterSystem>();

            mMonsterModel.Monsters[Id - 3].Position.RegisterOnValueChanged(OnPositionChanged);
            mMonsterModel.Monsters[Id - 3].bIsAlive.RegisterOnValueChanged(OnbIsAliveChanged);
            mMonsterModel.Monsters[Id - 3].MonsterModel.RegisterOnValueChanged(OnMonsterModelChanged);

            Reborn();
        }

        private void StartMove()
        {
            if (MoveCorotine == null)
            {
                MoveCorotine = StartCoroutine(this.CoroutineMove());
            }
        }

        private void Reborn()
        {
            int id = Id - 3;
            string monstertype = mMonsterModel.Monsters[id].MonsterModel.Value;
            if (monstertype.Equals("")) return;
            MonsterData data = mMonsterSystem.GetMonsterDataById(monstertype);

            mMonsterModel.Monsters[id].monsterData = data;
            mMonsterModel.Monsters[id].ID.Value = Id;
            mMonsterModel.Monsters[id].Life.Value = data.Life;
            mMonsterModel.Monsters[id].Speed.Value = data.Speed;
            mMonsterModel.Monsters[id].bIsFlying.Value = data.bIsFlying;
            mMonsterModel.Monsters[id].bIsInPlace.Value = true;
            mMonsterModel.Monsters[id].bIsAlive.Value = true;

            SetLocationImmediately();
            OnMonsterModelChanged(monstertype);
            OnbIsAliveChanged(true);
        }

        private void OnPositionChanged(Vector2Int newValue)
        {
            NextLocation = new Vector3(newValue.x, transform.position.y, newValue.y);
            StartMove();
        }

        private void OnbIsAliveChanged(bool newValue)
        {
            if (newValue) OutOfGround();
            else IntoTheGround();
        }

        private void OnMonsterModelChanged(string newValue)
        {
            if (newValue.Equals("")) return;
            GetComponent<MeshRenderer>().material = mMonsterSystem.GetMateirialByMonsterType(newValue);
        }

        private void OutOfGround()
        {
            NextLocation = new Vector3(transform.position.x, 0.7f, transform.position.z);
            StartMove();
        }

        private void IntoTheGround()
        {
            NextLocation = new Vector3(transform.position.x, 0f, transform.position.z);
            StartMove();
        }

        private void SetLocationImmediately()
        {
            Vector2Int Loc2 = mMonsterModel.Monsters[Id - 3].Position.Value;
            transform.position = new Vector3(Loc2.x, 0, Loc2.y);
        }

        private IEnumerator CoroutineMove()
        {
            while (true)
            {
                transform.position = Vector3.Lerp(transform.position, NextLocation, Time.deltaTime * 3);

                if (Mathf.Approximately(transform.position.x, NextLocation.x) &&
                    Mathf.Approximately(transform.position.y, NextLocation.y) &&
                    Mathf.Approximately(transform.position.z, NextLocation.z)
                    )
                {
                    StopMoveCorotine();
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private void StopMoveCorotine()
        {
            if (MoveCorotine == null) return;
            StopCoroutine(MoveCorotine);
            MoveCorotine = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
