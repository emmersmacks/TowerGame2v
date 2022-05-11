using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace TowerGame.Game.Environment
{
    public class ItemsNotice : MonoBehaviour
    {
        private GameObject _notiseObj;

        private void Start()
        {
            _notiseObj = (GameObject)Resources.Load("ItemNotification");
        }

        public async UniTask ShowNotice(Sprite sprite)
        {
            var instantiateObj = Instantiate(_notiseObj, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity, transform);
            instantiateObj.transform.Find("Canvas").Find("Image").GetComponent<Image>().sprite = sprite;

            await Task.Delay(3000);

            Destroy(instantiateObj);
        }

        public async UniTask ShowNotice(Sprite sprite, int count)
        {
            var instantiateObj = Instantiate(_notiseObj, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity, transform);

            instantiateObj.transform.Find("Canvas").Find("Image").GetComponent<Image>().sprite = sprite;
            instantiateObj.transform.Find("Canvas").Find("Text").GetComponent<Text>().text = count.ToString();

            await NotificationAnimation(instantiateObj, 10);
            await Task.Delay(3000);

            Destroy(instantiateObj);
        }

        public async UniTask NotificationAnimation(GameObject obj, int animationTimeInMilliseconds)
        {
            for (int count = 0; count < animationTimeInMilliseconds; count++)
            {
                obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + 0.1f);
                await Task.Delay(50);
            }

        }
    }
}

