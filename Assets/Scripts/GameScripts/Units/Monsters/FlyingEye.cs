using System.Collections;
using UnityEngine;
using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

namespace TowerGame.Game.Level.Units.Monsters
{
    public class FlyingEye : MonsterScript
    {
        [SerializeField] private float _speed;

        private MonsterState _currentState;

        MonsterAnimationState CurrentAnimation
        {
            get { return (MonsterAnimationState)_animator.GetInteger("State"); }
            set { _animator.SetInteger("State", (int)value); }
        }

        void Update()
        {
            if (_currentState != MonsterState.isDead)
            {
                if (_currentState == MonsterState.isHit)
                    CurrentAnimation = MonsterAnimationState.hit;
                else
                    CurrentAnimation = MonsterAnimationState.fly;
                Move();
            }
            else
                CurrentAnimation = MonsterAnimationState.dead;
        }

        private void Move()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * _direction.x * 0.2f, 0.2f);
            bool isWall = colliders.All(n => n.gameObject.tag == "Wall");
            if (colliders.Length > 0 && isWall)
                _direction *= -1f;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }

        private async void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Unit>())
            {
                await HitAnimation(300);
                collision.GetComponent<HealthController>().GetDamage(20);
            }
        }

        private async UniTask HitAnimation(int timeInMilliseconds)
        {
            _currentState = MonsterState.isHit;
            await Task.Delay(timeInMilliseconds);
            _currentState = MonsterState.isFly;
        }

        enum MonsterState
        {
            isFly,
            isHit,
            isDead,
        }

        enum MonsterAnimationState
        {
            fly,
            hit,
            dead,
        }
    }
}

