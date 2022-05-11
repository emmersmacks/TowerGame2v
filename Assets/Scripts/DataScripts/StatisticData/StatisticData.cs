using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data.Controller.Binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game.Data.Player.Statistic
{
    public class StatisticData : MonoBehaviour
    {
        public StaticticDataStruct data;
        private string _path = "/Saves/Statistic.bs";


        private void Start()
        {
            if(!File.Exists(Application.dataPath + _path))
            {
                SetDefoltValuesData();
                Debug.Log("FirstStart");
            }
            else
            {
                data = new StaticticDataStruct();
                data = LoadData.Load(ref data, _path);
                Debug.Log("Data loaded!");

            }

        }

        private void OnApplicationQuit()
        {
            SaveData.Save(data, _path);
        }

        public void SetDefoltValuesData()
        {
            data = new StaticticDataStruct();
            data.monsterKillCount = 0;
            SaveData.Save(data, _path);
        }
    }

    [System.Serializable]
    public class StaticticDataStruct
    {
        public int monsterKillCount;
    }
}

