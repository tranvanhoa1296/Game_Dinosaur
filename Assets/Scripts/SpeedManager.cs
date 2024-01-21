using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager instance;

    public float speed = -2f; 
    public float maxSpeed = -10f;
    public float acceleration = 0.1f; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
        if (speed > maxSpeed)
        {
            speed -= acceleration * Time.deltaTime;
        }
    }

    public float GetCurrentSpeed()
    {
        return speed;
    }
}
