using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotFiller : MonoBehaviour
{
    List<IItem> shopItemsList;

    private void Start()
    {
        shopItemsList = new List<IItem>();
        shopItemsList.Add(new HealthPotion());

        for (int i = 0; i <= shopItemsList.Count && i <= transform.childCount; i++)
        {
            var slot = transform.GetChild(i);
            Instantiate(Resources.Load(shopItemsList[i].PrefabLink, typeof(GameObject)), slot.transform.position, Quaternion.identity, slot);
            slot.GetComponent<ShopSlot>().Init(shopItemsList[i].Price, shopItemsList[i]);
        }
    }
}
