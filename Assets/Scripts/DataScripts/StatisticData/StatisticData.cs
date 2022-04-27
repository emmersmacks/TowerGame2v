using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.data.controller.binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace game.data.player.statistic
{
    public class StatisticData : MonoBehaviour
    {
        public StaticticDataStruct data;
        private string _path = "/StatisticData.bs";


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
            data.souls = 0;
            data.money = 0;
            data.floor = 0;
            data.monsterDeadCount = 0;
            data.isNoFirstGameStart = true;
            SaveData.Save(data, _path);
        }
    }

    [System.Serializable]
    public class StaticticDataStruct
    {
        public int souls;
        public int money;
        public int floor;
        public int monsterDeadCount;
        public bool isNoFirstGameStart;
    }
}

