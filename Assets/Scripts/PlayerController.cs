using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

   
    public LayerMask groundLayer;
   
    public Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        Debug.Log(IsGrounded());
    }

    
    private bool IsGrounded()
    {
        return Physics2D.IsTouchingLayers(coll, groundLayer);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.instance.GameOver();
        }
    }
}
