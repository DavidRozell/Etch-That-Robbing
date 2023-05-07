using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip collideSound;
    private AI copAI;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        audioSource = gameManager.GetComponent<AudioSource>();
        copAI = GameObject.Find("Police").GetComponent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.health--;
            if (gameManager.health <= 0)
            {
                BoxCollider2D boxCollider2D = other.gameObject.GetComponent<BoxCollider2D>();
                TiltJump tiltJump = other.gameObject.GetComponent<TiltJump>();
                boxCollider2D.enabled = false;
                tiltJump.enabled = false;
                tiltJump.Die();
                copAI.enabled = false; 
            }
            audioSource.PlayOneShot(collideSound);
            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                audioSource.PlayOneShot(collideSound);
                Destroy(gameObject);
            }
        }
    }
}
