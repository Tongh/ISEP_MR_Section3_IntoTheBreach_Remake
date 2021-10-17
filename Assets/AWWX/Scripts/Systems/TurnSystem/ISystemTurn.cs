using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface ISystemTurn : ISystem
    {
        void NextPhase();
    }

    public class SystemTurn : AbstractSystem, ISystemTurn
    {
        private IGameModel mGameModel;

        protected override void OnInit()
        {
            mGameModel = this.GetModel<IGameModel>();

            mGameModel.TurnPhase.RegisterOnValueChanged(OnTurnPhaseChanged);

            this.RegisterEvent<EventGameBegin>(OnGameBegin);
        }

        private void OnGameBegin(EventGameBegin e)
        {
            NextPhase();
        }

        private void OnTurnPhaseChanged(int newValue)
        {
            ETurnState newPhase = (ETurnState)newValue;

            if (newPhase == ETurnState.TurnBeginning)
            {
                this.SendEvent<EventTurnBeginning>();
            }
            else if (newPhase == ETurnState.MonsterMovePhase)
            {
                this.SendEvent<EventMonsterMovePhase>();
            }
            else if (newPhase == ETurnState.FutureShowing)
            {
                this.SendEvent<EventFutureShowing>();
            }
            else if (newPhase == ETurnState.PlayerActionPhase)
            {
                this.SendEvent<EventPlayerActionPhase>();
            }
            else if (newPhase == ETurnState.MonsterAttackPhase)
            {
                this.SendEvent<EventMonsterAttackPhase>();
            }
            else if (newPhase == ETurnState.TurnEnding)
            {
                this.SendEvent<EventTurnEnding>();
            }
        }

        public void NextPhase()
        {
            if (mGameModel.TurnPhase.Value == (int)ETurnState.TurnEnding)
            {
                mGameModel.TurnPhase.Value = (int)ETurnState.TurnBeginning;
            }
            else
            {
                mGameModel.TurnPhase.Value++;
            }
        }
    }
}
