using UnityEngine;
using Zenject;
using TowerGame.Data.Player;
using TowerGame.Shop.Data;

namespace TowerGame.Shop.Controllers
{
    public class BuyController : MonoBehaviour
    {
        [Inject] PlayerData playerData;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    var ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var raycast = Physics2D.Raycast(ray, Vector2.zero);
                    if (raycast.transform.gameObject.GetComponent<ShopSlot>() != null)
                    {
                        var slot = raycast.transform.gameObject.GetComponent<ShopSlot>();
                        ItemBuy(slot);
                    }
                }

            }
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var raycast = Physics2D.Raycast(ray, Vector2.zero);
                if (raycast.transform.gameObject.GetComponent<ShopSlot>())
                {
                    var slot = raycast.transform.gameObject.GetComponent<ShopSlot>();
                    ItemBuy(slot);
                }
            }
        }

        private void ItemBuy(ShopSlot slot)
        {
            if (playerData.data.money >= slot.price && playerData.data.money != 0)
            {
                Debug.Log("item buy");
                playerData.data.money -= slot.price;
                if (playerData.data.Inventory.Contains(slot.shopItem))
                {
                    var itemIndex = playerData.data.Inventory.IndexOf(slot.shopItem);
                    Debug.Log(playerData.data.Inventory[0]);
                }
                else
                {
                    playerData.data.Inventory.Add(slot.shopItem);
                    Debug.Log("new item element create");
                }

            }
            else
            {
                Debug.Log("not enough money");
            }
        }
    }
}

