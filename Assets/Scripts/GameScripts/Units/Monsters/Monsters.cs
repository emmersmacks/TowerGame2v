using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Monsters : Unit
{
    protected Animator _animator;
    protected Vector3 _direction;
    protected SpriteRenderer sprite;

    public static Action Dead;


    private void Start()
    {
        _direction = transform.right;
        _animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (_direction.x < 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }

    public override void DeadAction()
    {
        if (Dead != null)
            Dead();
        Destroy(gameObject);
    }
}
