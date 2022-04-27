using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TorchScript : MonoBehaviour
{
    [SerializeField] float animationTime;
    [SerializeField] float minIntencity;
    [SerializeField] float maxIntencity;

    private bool isStart;
    [SerializeField] private Transform _lightScale;

    public GameObject lightSpriteWithAnimation;

    private void Start()
    {
        isStart = true;
        FireAnimation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerLight");

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

    public async void FireAnimation()
    {
        while(isStart && _lightScale != null)
        {
            var intensivity = Random.Range(minIntencity, minIntencity + 0.5f);
            _lightScale.localScale = new Vector3(intensivity, intensivity, intensivity);
            await Task.Delay((int)animationTime);
            intensivity = Random.Range(minIntencity, minIntencity + 0.5f);
            _lightScale.localScale = new Vector3(intensivity, intensivity, intensivity);
            await Task.Delay((int)animationTime);
        }
    }

    private void WindFireAnimationStart()
    {
        lightSpriteWithAnimation.GetComponent<Animator>().Play("WindFire", 0);
    }

    private void OnApplicationQuit()
    {
        isStart = false;
    }
}
