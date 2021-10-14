using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")] public float horizontalForce;
    [Range(0.0f, 1.0f)]
    public float decay;
    public Bounds bounds;
    public int frameDelay;

    [Header("Player Attack")]
    public Transform bulletSpawn;

    private Rigidbody2D playerRB;
    private BulletManager bulletManager;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    void FixedUpdate()
    {
        Move();
        CheckBounds();
        CheckFire();
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

    private void CheckFire()
    {
        if(Time.frameCount % frameDelay == 0 && Input.GetAxisRaw("Jump") > 0)
        {
            bulletManager.GetBullet(bulletSpawn.position, BulletType.PLAYER);
        }
    }
}