using UnityEngine;

namespace TowerGame.Game.Environment.Controllers
{
    public class ChestController : MonoBehaviour, IInteractableObject
    {
        [SerializeField] private int _money;
        [SerializeField] private Sprite _image;
        [SerializeField] private Sprite _chestOpen;

        private bool _isOpen = false;
        private ItemsNotice _notice;

        private void Start()
        {
            _notice = GetComponent<ItemsNotice>();
        }

        public void InteractActionStart()
        {
            if (!_isOpen)
            {
                int currentMoney = PlayerPrefs.GetInt("money");
                PlayerPrefs.SetInt("money", currentMoney + _money);

                GetComponentInChildren<SpriteRenderer>().sprite = _chestOpen;
                _notice.ShowNotice(_image, _money);
                _isOpen = true;
            }
        }
    }
}

