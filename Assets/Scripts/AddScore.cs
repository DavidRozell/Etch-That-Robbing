using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        audioSource = gameManager.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.ShowScore();
            gameManager.score++;
            gameManager.scoreText.text = gameManager.score.ToString();
            audioSource.PlayOneShot(gameManager.scoreSound);
        }
    }
}
