using UnityEngine;
using Zenject;
using System.Threading.Tasks;
using TowerGame.Data.Player;

namespace TowerGame.Game.Level.Units.Character
{
    public class SwordAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _hitBox;

        [Inject] private PlayerData _data;

        private SpriteRenderer _sprite;
        private AudioSource _swordSound;
        private AnimationController _animationController;


        private void Start()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _swordSound = GetComponent<AudioSource>();
            _animationController = GetComponent<AnimationController>();
        }

        public async void Attack()
        {
            if (_animationController.hitAnimationStart == false)
            {
                _swordSound.enabled = true;
                _animationController.hitAnimationStart = true;

                var hitBoxInst = Instantiate(_hitBox, new Vector2(transform.position.x, transform.position.y + 1), HitBoxRotation(), transform);
                hitBoxInst.GetComponent<HitColliderScript>().damage = (int)_data.data.damage;

                await Task.Delay((int)(_data.data.attackSpeed * 1000));

                Destroy(hitBoxInst);
                _animationController.hitAnimationStart = false;
                _swordSound.enabled = false;
            }
        }

        public Quaternion HitBoxRotation()
        {
            if (_sprite.flipX)
                return Quaternion.Euler(new Vector3(0, 180, 0));
            else
                return Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}

