using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")] public float horizontalForce;
    [Range(0.0f, 1.0f)]
    public float decay;
    public Bounds bounds;

    private Rigidbody2D playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        playerRB.AddForce(new Vector2(x * horizontalForce, 0.0f));

        playerRB.velocity *= (1.0f - decay);
    }
    
    private void CheckBounds()
    {
        // left vbound
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }


        // right bound
        if(transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}