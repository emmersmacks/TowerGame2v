using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Linq;

public class ExitAreaScript : MonoBehaviour
{
    public event Action EndLevel;
    Animator animator;
    bool isAnimationStart;

    public void Start()
    {
        animator = GetComponent<Animator>();
        isAnimationStart = false;
    }

    public async void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CharacterInputController>() && !isAnimationStart)
        {
            isAnimationStart = true;
            collision.GetComponent<CharacterInputController>().canMove = false;
            SpawnPlayerInTeleport(collision.gameObject);
            await StartAnimation();
            collision.GetComponent<CharacterInputController>().canMove = true;
            EndLevel();
        }
        
    }

    public async Task StartAnimation()
    {
        if(animator != null)
        {
            animator.Play("LightPortalAnimation", 0);
            await Task.Delay(2000);

        }
    }

    public void SpawnPlayerInTeleport(GameObject player)
    {
        var playerPosition = new Vector2(transform.position.x, transform.position.y - 1f);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = playerPosition;
    }
}
