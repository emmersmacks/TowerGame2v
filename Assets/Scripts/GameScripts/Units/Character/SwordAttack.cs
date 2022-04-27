using System.Collections;
using UnityEngine;
using Zenject;
using game.data.player;
using System.Threading.Tasks;


public class SwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject _hitBox;

    [Inject] PlayerData playerData;

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
        if(_animationController.hitAnimationStart == false)
        {
            _swordSound.enabled = true;
            _animationController.hitAnimationStart = true;

            var hitBoxInst = Instantiate(_hitBox, new Vector2(transform.position.x, transform.position.y + 1), HitBoxRotation(), transform);
            hitBoxInst.GetComponent<HitBoxScript>().damage = (int)playerData.data.damage;

            await Task.Delay((int)(playerData.data.attackSpeed * 1000));

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
