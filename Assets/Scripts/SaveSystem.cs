using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace DefaultNamespace
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class SaveSystem
    {
        private static string PATH = Application.persistentDataPath + "/AppData/game.save";
        

        public static void SaveGame(GameData game)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(PATH, FileMode.Create);
            formatter.Serialize(fileStream, game);
            fileStream.Close();
        }

        public static void EraseGame()
        {
            SaveGame(Initialize());
        }

        public static GameData LoadGame()
        {
            if (File.Exists(PATH))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(PATH, FileMode.Open);
                GameData data = formatter.Deserialize(fileStream) as GameData;
                fileStream.Close();
                return data;
            }
            else
            {
                return Initialize();
            }
        }

        private static GameData Initialize()
        {
            throw new NotImplementedException();
        } 

        [Serializable]
        public class GameData
        {
            private bool[] _levelPassed = new bool[10];
            private int _maxScore;
        }
    }
}