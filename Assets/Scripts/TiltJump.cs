using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltJump : MonoBehaviour
{
    public float jumpForce;
    public float tiltThreshold;
    private bool hasLanded;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip gameOverSound;
    public AudioClip jumpSound;
    public AudioClip jumpLandSound;
    public ParticleSystem jumpLandParticles;

    private void Start()
    {
        jumpLandParticles.Play();
        rb = GetComponent<Rigidbody2D>();
        hasLanded = true;
    }

    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (acceleration.y > tiltThreshold && rb.velocity.y < 1f && transform.position.y < 0)
        {
            audioSource.PlayOneShot(jumpSound);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y < 1f && transform.position.y < 0)
            {
                jumpLandParticles.Stop();
                audioSource.PlayOneShot(jumpSound);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }

        if (rb.velocity.y < 1f && transform.position.y < 0 && !hasLanded)
        {
            jumpLandParticles.Play();
            hasLanded = true;
            audioSource.PlayOneShot(jumpLandSound);
        }
        else
        {
            if (rb.velocity.y > 1f && transform.position.y > 0)
            {
                hasLanded = false;
            }
        }
    }

    public void Die()
    {
        jumpLandParticles.Stop();
        audioSource.PlayOneShot(gameOverSound);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.AddForce(new Vector2(0f, 20), ForceMode2D.Impulse);
        rb.AddTorque(220);
    }
}
