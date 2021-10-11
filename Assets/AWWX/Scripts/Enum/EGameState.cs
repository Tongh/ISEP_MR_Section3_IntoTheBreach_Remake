namespace OutOfTheBreach
{
    public enum EGameState
    {
        GameSetting = -1, // Select Mecha
        GamePreparing = 0, // Map
        MonsterComing,
        MechaInPlacing,
        MonsterMovePhase,
        FutureShowing,
        PlayerActionPhase,
        MonsterAttackPhase,
        TurnEnding,
        GameEnding
    }
}
