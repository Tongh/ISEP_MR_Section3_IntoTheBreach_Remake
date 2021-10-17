using System;
using UnityEngine;

namespace OutOfTheBreach
{
    [Serializable]
    public struct FDataAllMapGround
    {
        public FDataMapStyle[] Styles;
    }

    [Serializable]
    public struct FDataMapStyle
    {
        public string StyleId;
        public string StyleName;
        public FDataMapGround[] Grounds;
    } 

    [Serializable]
    public struct FDataMapGround
    {
        public ETypeGround GroundType;
        public string GroundName;
        public string Description;
    } 
}
