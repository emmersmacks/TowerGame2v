using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool hitAnimationStart;
    protected Animator animator;
    private CharacterInputController inputScript;

    protected AnimationState CurrentAnimation
    {
        get { return (AnimationState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Start()
    {
        inputScript = GetComponent<CharacterInputController>();
        animator = GetComponentInChildren<Animator>();
        hitAnimationStart = false;
    }

    private void Update()
    {
        if(inputScript._currentState == CharacterState.isDead)
            CurrentAnimation = AnimationState.dead;

        if (inputScript.isWallSliding)
        {
            CurrentAnimation = AnimationState.hangWall;
        }
        else if (!hitAnimationStart)
        {
            if (inputScript._currentState == CharacterState.onJump)
            {
                CurrentAnimation = AnimationState.jump;
            }
            else if (inputScript._joystick.Horizontal != 0 || Input.GetButton("Horizontal"))
            {
                CurrentAnimation = AnimationState.go;
            }
            else CurrentAnimation = AnimationState.idle;
        }
        else if (inputScript._currentState != CharacterState.isDead)
            CurrentAnimation = AnimationState.hit;

    }

    public enum AnimationState
    {
        idle,
        go,
        jump,
        hit,
        hangWall,
        dead,
    }
}
