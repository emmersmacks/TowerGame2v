using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
