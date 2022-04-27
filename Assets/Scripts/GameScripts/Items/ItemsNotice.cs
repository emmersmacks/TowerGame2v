using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ItemsNotice : MonoBehaviour
{
    private GameObject notiseObj;

    private void Start()
    {
        notiseObj = (GameObject)Resources.Load("ItemNotification");
    }

    public async void ShowNotice(Sprite sprite)
    {
        var instantiateObj = Instantiate(notiseObj, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity, transform);
        instantiateObj.transform.Find("Canvas").Find("Image").GetComponent<Image>().sprite = sprite;

        await Task.Delay(3000);

        Destroy(instantiateObj);
    }

    public async void ShowNotice(Sprite sprite, int count)
    {
        var instantiateObj = Instantiate(notiseObj, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity, transform);

        instantiateObj.transform.Find("Canvas").Find("Image").GetComponent<Image>().sprite = sprite;
        instantiateObj.transform.Find("Canvas").Find("Text").GetComponent<Text>().text = count.ToString();

        NotificationAnimation(instantiateObj, 10);

        await Task.Delay(3000);

        Destroy(instantiateObj);
    }

    public async void NotificationAnimation(GameObject obj, int animationTimeInMilliseconds)
    {
        for(int count = 0; count < animationTimeInMilliseconds; count++)
        {
            obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + 0.1f);
            await Task.Delay(50);
        }
        
    }
}
