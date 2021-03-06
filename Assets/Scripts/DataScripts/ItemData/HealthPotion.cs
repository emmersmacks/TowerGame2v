using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data.Player;
using TowerGame.Data.Player;

namespace TowerGame.Data.Items.Potions
{
    [System.Serializable]
    public class HealthPotion : Potion
    {
        private int amountHealthAdded;

        public HealthPotion()
        {
            Name = "Health potion";
            Description = "Restores" + amountHealthAdded + "health";
            Count = 1;
            Price = 100;
            amountHealthAdded = 25;
            PrefabLink = "Prefabs/Items/PotionHealth";
        }

        public override void ActivatePotion(PlayerDataStruct data)
        {
            data.hp += amountHealthAdded;
        }
    }
}

