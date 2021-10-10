using UnityEngine;
using FrameworkDesign;
using System.IO;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class JsonStorage : MyJsonUtility
    {
        public override MapMakerConfigData LoadMapMakerConfigData()
        {
            const string FileName = "MapMakerConfigData.json";
            return ReadJsonStructFromFile<MapMakerConfigData>(FileName);
        }
    }

    public abstract class MyJsonUtility : IStorage
    {
        protected string JsonPath = Application.dataPath + "/AWWX/Config/Json/";

        protected T ReadJsonStructFromFile<T>(string JsonFile)
        {
            string JsonString = ReadJsonStringFromFile(JsonFile);
            return JsonUtility.FromJson<T>(JsonString);
        }

        protected string ReadJsonStringFromFile(string JsonFile)
        {
            string ret;
            string JsonFileFromPath = JsonPath + JsonFile;

            Assert.IsTrue(File.Exists(JsonFileFromPath), "File Not Exist! " + JsonFileFromPath);

            ret = File.ReadAllText(JsonFileFromPath);
            return ret;
        }

        protected void SaveJsonStructToFile<T>(T JsonStruct, string JsonFile)
        {
            string JsonString = JsonUtility.ToJson(JsonStruct, true);
            SaveJsonStringToFile(JsonString, JsonFile);
        }

        protected void SaveJsonStringToFile(string JsonString, string JsonFile)
        {
            string JsonFileFromPath = JsonPath + JsonFile;

            if (!File.Exists(JsonFileFromPath))
            {
                File.Create(JsonFileFromPath);
            }
            File.WriteAllText(JsonFileFromPath, JsonString);
        }

        public abstract MapMakerConfigData LoadMapMakerConfigData();
    }
}
