using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    // Related to gameplay, and some not well classified
    public static class GameplayLibrary 
    {
        public static Texture2D GetMechaPreviewTex(string MechaId)
        {
            string astPath = "Prefabs/Mecha/" + MechaId;

            GameObject obj = Resources.Load(astPath) as GameObject;

            Assert.IsNotNull(obj, MechaId + " prefab not find!");

            return AssetPreview.GetAssetPreview(obj);
        }
    }
}
