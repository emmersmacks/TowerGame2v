using System;
using UnityEngine;
using System.Threading.Tasks;

namespace TowerGame.Game.Level.Units.Character
{
    public class CharacterInputController : Unit
    {
        [Header("Input Controllers")]
        [SerializeField] public Joystick joystick;

        [Header("Wall jump")]
        [SerializeField] private float _wallJumpTime;
        [SerializeField] private float _wallSlideSpeed;
        [SerializeField] private float _wallDistance;
        [SerializeField] public bool _isWallSliding;
        [SerializeField] private RaycastHit2D _wallCheckHit;

        [Header("Grounded")]
        [SerializeField] public LayerMask groundLayer;

        public CharacterState currentState;
        public bool canMove;

        private Vector3 _moveDirection;
        private ControllerAction _actionController;

        public event Action OnDeadCharacter = default;

        private void Start()
        {
            currentState = CharacterState.onGround;
            _actionController = GetComponent<ControllerAction>();
            canMove = true;
        }

        private void Update()
        {
            _actionController.FlipSprite(_moveDirection);

            if (canMove)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (currentState == CharacterState.onGround || _isWallSliding)
                    {
                        _actionController.Jump();
                        currentState = CharacterState.onJump;
                    }
                }

                if (_wallCheckHit && currentState != CharacterState.onGround && _moveDirection.x != 0)
                    _isWallSliding = true;
                else
                    _isWallSliding = false;
            }
        }

        private void FixedUpdate()
        {
            if (canMove)
            {
                if (currentState != CharacterState.onWall)
                {
                    _moveDirection = transform.right * joystick.Horizontal;
                    _actionController.MoveHorizontal(_moveDirection);
                }

                if (currentState != CharacterState.onWall && Input.GetButton("Horizontal"))
                {
                    _moveDirection = transform.right * Input.GetAxis("Horizontal");
                    _actionController.MoveHorizontal(_moveDirection);
                }

                //WallJump
                if (_moveDirection.x > 0)
                {
                    _wallCheckHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(_wallDistance, 0), _wallDistance, groundLayer);

                }
                else
                {
                    _wallCheckHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(-_wallDistance, 0), _wallDistance, groundLayer);
                }

                if (_isWallSliding)
                {
                    _actionController.HangWall(_wallSlideSpeed);
                }
            }
        }

        public async void FreazePlayer(float timePerSeconds)
        {
            var time = timePerSeconds * 1000f;
            canMove = false;
            await Task.Delay((int)time);
            canMove = true;
        }

        public override void DeadAction()
        {
            if (currentState != CharacterState.isDead)
                OnDeadCharacter();
            currentState = CharacterState.isDead;
        }
    }


    public enum CharacterState
    {
        onGround,
        onWall,
        onJump,
        onHit,
        isDead,
        freeze,
    }
}




