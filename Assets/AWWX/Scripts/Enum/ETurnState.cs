namespace OutOfTheBreach
{
    public enum ETurnState
    {
        None,
        TurnBeginning,
        MonsterMovePhase, // Monster Move To Target
        FutureShowing, // Monster Attack Target & New Monster Position
        PlayerActionPhase, // Move, Attack, End
        MonsterAttackPhase, // Monster Attack, New Monster Out
        TurnEnding,
    }
}
