using System;
using UnityEngine;

namespace OutOfTheBreach
{
    [Serializable]
    public struct MapMakerConfigData
    {
        public StyleMapConfigData[] Styles;
    }

    [Serializable]
    public struct StyleMapConfigData
    {
        public string StyleId;
        public string StyleName;
        public MapGroundConfigData[] Grounds;
    } 

    [Serializable]
    public struct MapGroundConfigData
    {
        public EMapGroundType GroundType;
        public string GroundName;
        public string GroundMaterial;
    } 
}
