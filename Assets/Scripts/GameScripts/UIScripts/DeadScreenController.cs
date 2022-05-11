using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Game.Level.Controllers;
using TowerGame.Game.Level.Units.Character;

namespace TowerGame.Game.Level.UI.Controllers
{
    public class DeadScreenController : MonoBehaviour
    {
        [SerializeField] private CharacterInputController _actionScript;
        [SerializeField] private Image _deadScreenImage;
        [SerializeField] private GameObject _infoPanel;

        private bool _showDeadPanel;

        Tween DOTweenAnim;

        private void Start()
        {
            _showDeadPanel = false;
            _actionScript.OnDeadCharacter += ShowDeadScreen;
        }

        private void Update()
        {
            if (_showDeadPanel)
            {
                _showDeadPanel = false;
                _infoPanel.SetActive(true);
            }
        }

        private void ShowDeadScreen()
        {
            _deadScreenImage.DOFade(1f, 0.5f);
            DOTweenAnim = _deadScreenImage.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 1, 1f);
            if (DOTweenAnim != null)
                if (DOTweenAnim.active)
                    _showDeadPanel = true;
        }
    }
}

