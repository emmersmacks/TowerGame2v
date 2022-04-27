using System;
using UnityEngine;
using System.Threading.Tasks;

public class CharacterInputController : Unit
{
    [Header("Input Controllers")]
    public Joystick _joystick;

    [Header("Wall jump")]
    public float wallJumpTime;
    public float wallSlideSpeed;
    public float wallDistance;
    public bool isWallSliding;
    RaycastHit2D wallCheckHit;

    [Header("Grounded")]
    public LayerMask groundLayer;

    private Vector3 _moveDirection;
    public CharacterState _currentState;
    private ControllerAction _actionController;

    public event Action OnDeadCharacter = default;

    public bool canMove;

    private void Start()
    {
        _currentState = CharacterState.onGround;
        _actionController = GetComponent<ControllerAction>();
        canMove = true;
    }

    private void Update()
    {
        _actionController.FlipSprite(_moveDirection);

        if(canMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (_currentState == CharacterState.onGround || isWallSliding)
                {
                    _actionController.Jump();
                    _currentState = CharacterState.onJump;
                }
            }

            if (wallCheckHit && _currentState != CharacterState.onGround && _moveDirection.x != 0)
                isWallSliding = true;
            else
                isWallSliding = false;
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            if (_currentState != CharacterState.onWall)
            {
                _moveDirection = transform.right * _joystick.Horizontal;
                _actionController.MoveHorizontal(_moveDirection);
            }

            if (_currentState != CharacterState.onWall && Input.GetButton("Horizontal"))
            {
                _moveDirection = transform.right * Input.GetAxis("Horizontal");
                _actionController.MoveHorizontal(_moveDirection);
            }

            //WallJump
            if (_moveDirection.x > 0)
            {
                wallCheckHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(wallDistance, 0), wallDistance, groundLayer);

            }
            else
            {
                wallCheckHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(-wallDistance, 0), wallDistance, groundLayer);
            }

            if (isWallSliding)
            {
                _actionController.HangWall(wallSlideSpeed);
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
        if (_currentState != CharacterState.isDead)
            OnDeadCharacter();
        _currentState = CharacterState.isDead;
    }
}


public enum CharacterState
{
    onGround,
    onWall,
    onJump,
    onHit,
    isDead,
}



