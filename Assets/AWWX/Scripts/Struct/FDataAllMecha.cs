using System;

namespace OutOfTheBreach
{
    [Serializable]
    public struct FDataAllMecha
    {
        public FDataMecha[] MechasData;
    }

    [Serializable]
    public struct FDataMecha
    {
        public string MechaId;
        public string Description;
        public int Speed;
        public int Life;
        public bool bIsFlying;
        // public string MechaMaterial; // "Materials/Mecha/M_Mecha_" + MechaId
    }
}
