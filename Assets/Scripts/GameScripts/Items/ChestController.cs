using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour, IInteractableObject
{
    [SerializeField] int money;
    [SerializeField] Sprite _image;

    [SerializeField] Sprite _ChestOpen;
    bool isOpen = false;

    private ItemsNotice notice;

    private void Start()
    {
        notice = GetComponent<ItemsNotice>();
    }

    public void InteractActionStart()
    {
        if(!isOpen)
        {
            int currentMoney = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", currentMoney + money);

            GetComponentInChildren<SpriteRenderer>().sprite = _ChestOpen;
            notice.ShowNotice(_image, money);
            isOpen = true;
        }
    }
}
