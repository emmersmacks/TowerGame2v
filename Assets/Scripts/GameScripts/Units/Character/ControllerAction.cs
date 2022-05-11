using UnityEngine;
using Zenject;
using TowerGame.Data.Player;

namespace TowerGame.Game.Level.Units.Character
{
    public class ControllerAction : MonoBehaviour
    {
        [Inject] PlayerData playerData;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer _sprite;
        private CharacterInputController _inputController;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _inputController = GetComponent<CharacterInputController>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
                _inputController.currentState = CharacterState.onGround;
        }

        public void MoveHorizontal(Vector3 moveDirection)
        {
            if (_inputController.currentState == CharacterState.onJump)
                _rigidbody.velocity = new Vector2(moveDirection.x * (playerData.data.speed), _rigidbody.velocity.y);
            else
                _rigidbody.velocity = new Vector2(moveDirection.x * playerData.data.speed, _rigidbody.velocity.y);

        }

        public void Jump()
        {
            if (_inputController._isWallSliding)
            {
                _inputController.FreazePlayer(0.2f);
                _inputController.currentState = CharacterState.onJump;
                if (_sprite.flipX == true)
                    _rigidbody.velocity = new Vector2(playerData.data.jumpForce / 2, playerData.data.jumpForce);
                else
                    _rigidbody.velocity = new Vector2(-playerData.data.jumpForce / 2, playerData.data.jumpForce);
            }
            else
            {
                _rigidbody.AddForce(Vector3.up * playerData.data.jumpForce, ForceMode2D.Impulse);
                _inputController.currentState = CharacterState.onJump;
            }
            _inputController.currentState = CharacterState.onJump;


        }

        public void HangWall(float wallSlideSpeed)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, wallSlideSpeed, float.MaxValue));
        }

        public void FlipSprite(Vector3 moveDirection)
        {
            if (moveDirection.x < 0)
                _sprite.flipX = true;
            else if (moveDirection.x > 0)
                _sprite.flipX = false;
        }
    }
}



