using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltJump : MonoBehaviour
{
    public float jumpForce;
    public float tiltThreshold;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (acceleration.y > tiltThreshold && rb.velocity.y < 1f && transform.position.y < 0)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
