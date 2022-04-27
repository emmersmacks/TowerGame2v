using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 Target;
    public float TrackingSpeed = 5f;
    
    private void Update()
    {
        Vector3 currentPosition = Vector3.Lerp(transform.position, Target, TrackingSpeed * Time.deltaTime);
        transform.position = currentPosition;

        Target = new Vector3(player.transform.position.x, player.transform.position.y + 2, transform.position.z);
    }
}
