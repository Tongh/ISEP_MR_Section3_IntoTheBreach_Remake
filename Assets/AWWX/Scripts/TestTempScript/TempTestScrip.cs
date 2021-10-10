using UnityEngine;
using FrameworkDesign;
using System.IO;

namespace OutOfTheBreach
{
    public class TempTestScrip : MonoBehaviour, IController
    {
        //public MapMakerConfigData testdata;
        //public MapMakerConfigData readdata;
        public MechaConfigData readdata;
        string JsonFileFromPath;
        string filename = "MechasConfigData.json";

        // Start is called before the first frame update
        private void Start()
        {
            JsonFileFromPath = Application.dataPath + "/AWWX/Config/Json/" + filename;

            //{
            //    if (!File.Exists(JsonFileFromPath))
            //    {
            //        File.Create(JsonFileFromPath);
            //    }
            //    string json = JsonUtility.ToJson(testdata, true);
            //    File.WriteAllText(JsonFileFromPath, json);
            //    Debug.Log("Json Saved!");
            //}

            {
                if (File.Exists(JsonFileFromPath))
                {
                    string json = File.ReadAllText(JsonFileFromPath);
                    readdata = JsonUtility.FromJson<MechaConfigData>(json);
                }
            }
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return OutOfTheBreachGame.Interface;
        }
    }
}
