using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;

    void Update()
    {
        speed = SpeedManager.instance.GetCurrentSpeed();
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
