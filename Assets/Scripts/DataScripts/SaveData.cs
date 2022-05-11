using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Game.Data.Controller.Binary
{
    public class SaveData
    {
        public static void Save(object obj, string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(Application.dataPath + path);
            binaryFormatter.Serialize(fileStream, obj);
            fileStream.Close();
        }
    }
}

