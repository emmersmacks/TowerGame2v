using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace game.data.controller.binary
{
    public class LoadData
    {
        public static T Load<T>(ref T obj, string path)
        {

                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath + path, FileMode.Open);
                obj = (T)formatter.Deserialize(file);
                file.Close();
                return obj;

        }
    }
}

