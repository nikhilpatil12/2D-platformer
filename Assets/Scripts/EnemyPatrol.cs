using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public Transform groundCheck;
    private bool mustFlip;
    private bool mustPatrol;
    public LayerMask groundLayer;

    private void Start()
    {
        mustPatrol = true;
    }
    private void Update()
    {
        if(mustPatrol)
            Patrol();
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }

    void Patrol() { 
        if (mustFlip)
        {
            Flip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }
    
}