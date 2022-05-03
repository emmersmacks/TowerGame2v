using System.Collections.Generic;
using UnityEngine;
using game.data.controller.binary;
using System.IO;

namespace game.data.player
{
    public class PlayerData : MonoBehaviour
    {
        public PlayerDataStruct data;
        private string _path = "/PlayerData.bs";

        private void Start()
        {
            if (!File.Exists(Application.dataPath + _path))
            {
                SetDefoltValuesData();
                Debug.Log("FirstStart");
            }
            else
            {
                SetDefoltValuesData();
                data = new PlayerDataStruct();
                data = LoadData.Load(ref data, _path);
            }
        }

        private void OnApplicationQuit()
        {
            SaveData.Save(data, _path);
        }

        public void SetDefoltValuesData()
        {
            data = new PlayerDataStruct();
            data.hp = 100;
            data.damage = 25;
            data.chanceCritical = 5;
            data.speed = 6;
            data.attackSpeed = 0.3f;
            data.jumpForce = 12;
            data.criticalDamage = 25;
            data.floorCount = 0;
            data.souls = 0;
            data.money = 100;
            data.firstItemActive = null;
            data.secondItemActive = null;
            data.Inventory = new List<IItem>();
            data.Inventory.Add(new HealthPotion());
            SaveData.Save(data, _path);
        }
    }

    [System.Serializable]
    public class PlayerDataStruct
    {
        //characteristics
        public int hp;
        public float damage;
        public float speed;
        public float attackSpeed;
        public float jumpForce;
        public float chanceCritical;
        public float criticalDamage;

        //statistic
        public int floorCount;

        //money
        public int souls;
        public int money;

        //active inventory
        public IItem firstItemActive;
        public IItem secondItemActive;

        //all inventory
        public List<IItem> Inventory;
    }
}

