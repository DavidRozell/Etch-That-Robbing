using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float jumpForce;
    private bool hasLanded;
    private Rigidbody2D rb;
    public ParticleSystem jumpLandParticles;
    public GameObject player;

    private void Start()
    {
        jumpLandParticles.Play();
        player = GameObject.Find("Robber");
        rb = GetComponent<Rigidbody2D>();
        hasLanded = true;
    }

    private void Update()
    {
        if (rb.velocity.y < 1f && transform.position.y < 0 && player.transform.position.y > 1f)
        {
            jumpLandParticles.Stop();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (rb.velocity.y < 1f && transform.position.y < 0 && !hasLanded)
        {
            jumpLandParticles.Play();
            hasLanded = true;
        }
        else
        {
            if (rb.velocity.y > 1f && transform.position.y > 0)
            {
                hasLanded = false;
            }
        }
    }
}
