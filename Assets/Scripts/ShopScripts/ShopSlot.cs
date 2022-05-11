using TowerGame.Data.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TowerGame.Shop.Data
{
    public class ShopSlot : MonoBehaviour
    {
        public IItem shopItem;
        public int price;
        public Text priceText;

        public void Init(int price, IItem type)
        {
            priceText.text = price.ToString();
            this.price = price;
        }
    }
}

