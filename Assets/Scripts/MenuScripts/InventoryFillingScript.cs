using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using game.data.player;

public class InventoryFillingScript : MonoBehaviour
{
    [Inject] PlayerData playerData;

    private void Start()
    {
        for (int i = 0; i <= playerData.data.Inventory.Count && i <= transform.childCount; i++)
        {
            var slot = transform.GetChild(i);
            Instantiate(Resources.Load(playerData.data.Inventory[i].PrefabLink, typeof(GameObject)), slot.transform.position, Quaternion.identity, slot);
        }
    }
}
