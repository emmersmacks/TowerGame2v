using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace TowerGame.Game.Environment.Controllers
{
    public class TorchController : MonoBehaviour
    {
        [SerializeField] private float _animationTime;
        [SerializeField] private float _minIntencity;
        [SerializeField] private Transform _lightScale;

        public GameObject lightSpriteWithAnimation;
        private bool _isStart;

        private async void Start()
        {
            _isStart = true;
            await FireAnimation();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Rigidbody2D>())
            {
                var direction = collision.transform.GetComponent<Rigidbody2D>().velocity;
                if (direction.x > 0)
                    lightSpriteWithAnimation.GetComponent<SpriteRenderer>().flipX = false;
                else
                    lightSpriteWithAnimation.GetComponent<SpriteRenderer>().flipX = true;

                WindFireAnimationStart();
            }
        }

        public async UniTask FireAnimation()
        {
            while (_isStart && _lightScale != null)
            {
                var intensivity = Random.Range(_minIntencity, _minIntencity + 0.5f);
                _lightScale.localScale = new Vector3(intensivity, intensivity, intensivity);
                await Task.Delay((int)_animationTime);
                intensivity = Random.Range(_minIntencity, _minIntencity + 0.5f);
                _lightScale.localScale = new Vector3(intensivity, intensivity, intensivity);
                await Task.Delay((int)_animationTime);
            }
        }

        private void WindFireAnimationStart()
        {
            lightSpriteWithAnimation.GetComponent<Animator>().Play("WindFire", 0);
        }

        private void OnApplicationQuit()
        {
            _isStart = false;
        }
    }
}

