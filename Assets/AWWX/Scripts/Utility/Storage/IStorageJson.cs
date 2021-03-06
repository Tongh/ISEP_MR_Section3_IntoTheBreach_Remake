using UnityEngine;
using FrameworkDesign;
using System.IO;
using UnityEngine.Assertions;

namespace OutOfTheBreach
{
    public class StorageJson : IStorageJson
    {
        public override FDataAllMapGround LoadMapMakerConfigData()
        {
            const string FileName = "MapMakerConfigData.json";
            return ReadJsonStructFromFile<FDataAllMapGround>(FileName);
        }

        public override FDataAllMecha LoadMechaConfigData()
        {
            const string FileName = "MechasConfigData.json";
            return ReadJsonStructFromFile<FDataAllMecha>(FileName);
        }

        public override FDataAllMonster LoadMonsterConfigData()
        {
            const string FileName = "MonstersConfigData.json";
            return ReadJsonStructFromFile<FDataAllMonster>(FileName);
        }

        public override FDataAllAbility LoadAbilitiesConfigData()
        {
            const string FileName = "AbilitiesConfigData.json";
            return ReadJsonStructFromFile<FDataAllAbility>(FileName);
        }

        public override FDataAllEffect LoadEffectsConfigData()
        {
            const string FileName = "EffectsConfigData.json";
            return ReadJsonStructFromFile<FDataAllEffect>(FileName);
        }
    }

    public abstract class IStorageJson : IStorage
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

        public abstract FDataAllMapGround LoadMapMakerConfigData();
        public abstract FDataAllMecha LoadMechaConfigData();
        public abstract FDataAllMonster LoadMonsterConfigData();
        public abstract FDataAllAbility LoadAbilitiesConfigData();
        public abstract FDataAllEffect LoadEffectsConfigData();
    }
}
