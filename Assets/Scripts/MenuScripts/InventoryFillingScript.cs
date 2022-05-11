using UnityEngine;
using Zenject;
using UnityEngine.UI;
using TowerGame.Data.Player;

namespace TowerGame.Menu.Inventory
{
    public class InventoryFillingScript : MonoBehaviour
    {
        [Inject] PlayerData playerData;

        private void Start()
        {
            for (int i = 0; i <= playerData.data.Inventory.Count && i <= transform.childCount; i++)
            {
                var slot = transform.GetChild(i);
                var item = playerData.data.Inventory[i];
                Instantiate(Resources.Load(item.PrefabLink, typeof(GameObject)), slot.transform.position, Quaternion.identity, slot);
                var counterText = slot.GetChild(0).GetChild(0).GetComponent<Text>();
                counterText.text = item.Count.ToString();
            }
        }
    }
}

