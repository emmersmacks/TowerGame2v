using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data.Player;
using TowerGame.Data.Player;

namespace TowerGame.Data.Items.Potions
{
    [System.Serializable]
    public abstract class Potion : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public IItem Type { get; set; }
        public int Price { get; set; }
        public string PrefabLink { get; set; }

        public abstract void ActivatePotion(PlayerDataStruct data);
    }
}

