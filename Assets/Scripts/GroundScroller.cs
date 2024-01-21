using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float tileSizeX;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float speed = SpeedManager.instance.GetCurrentSpeed();
        float newPosition = Mathf.Repeat(Time.time * speed, tileSizeX);
        transform.position = startPosition + Vector3.right * newPosition;
    }

}
