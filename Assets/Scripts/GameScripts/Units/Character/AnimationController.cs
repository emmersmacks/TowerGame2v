using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame.Game.Level.Units.Character
{
    public class AnimationController : MonoBehaviour
    {
        public bool hitAnimationStart;
        protected Animator animator;
        private CharacterInputController _inputScript;

        protected AnimationState CurrentAnimation
        {
            get { return (AnimationState)animator.GetInteger("State"); }
            set { animator.SetInteger("State", (int)value); }
        }

        private void Start()
        {
            _inputScript = GetComponent<CharacterInputController>();
            animator = GetComponentInChildren<Animator>();
            hitAnimationStart = false;
        }

        private void Update()
        {
            if (_inputScript.canMove)
            {
                if (_inputScript.currentState == CharacterState.isDead)
                    CurrentAnimation = AnimationState.dead;

                if (_inputScript._isWallSliding)
                {
                    CurrentAnimation = AnimationState.hangWall;
                }
                else if (!hitAnimationStart)
                {
                    if (_inputScript.currentState == CharacterState.onJump)
                    {
                        CurrentAnimation = AnimationState.jump;
                    }
                    else if (_inputScript.joystick.Horizontal != 0 || Input.GetButton("Horizontal"))
                    {
                        CurrentAnimation = AnimationState.go;
                    }
                    else CurrentAnimation = AnimationState.idle;
                }
                else if (_inputScript.currentState != CharacterState.isDead)
                    CurrentAnimation = AnimationState.hit;
            }
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
}

