using UnityEngine;
using FrameworkDesign;
using System.IO;

namespace OutOfTheBreach
{
    public class TempTestScrip : MonoBehaviour, IController
    {
        //public MapMakerConfigData testdata;
        //public MapMakerConfigData readdata;
        //string JsonFileFromPath;

        // Start is called before the first frame update
        private void Start()
        {
            //JsonFileFromPath = Application.dataPath + "/AWWX/Config/Json/MapMakerConfigData.json";

            //{
            //    if (!File.Exists(JsonFileFromPath))
            //    {
            //        File.Create(JsonFileFromPath);
            //    }
            //    string json = JsonUtility.ToJson(testdata, true);
            //    File.WriteAllText(JsonFileFromPath, json);
            //    Debug.Log("Json Saved!");
            //}

            //{
            //    if (File.Exists(JsonFileFromPath))
            //    {
            //        string json = File.ReadAllText(JsonFileFromPath);
            //        readdata = JsonUtility.FromJson<MapMakerConfigData>(json);
            //    }
            //}
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
