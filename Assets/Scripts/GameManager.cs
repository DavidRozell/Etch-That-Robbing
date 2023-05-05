using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool canShake;
    private bool isShaking;
    public Vector2 startPosition;
    public GameObject prefab;
    public float tiltThreshold;
    public float moveSpeed;
    public float spawnDelay;
    public float destroyDelay;
    public int score;
    public int health;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip shakeSound;

    private void Start()
    {
        player = GameObject.Find("Robber");
        StartCoroutine(SpawnObjects());
    }

    private void Update()
    {
        healthText.text = health.ToString();

        Vector3 acceleration = Input.acceleration;
        if (canShake && acceleration.y > tiltThreshold && !isShaking)
        {
            isShaking = true;
            StartCoroutine(Restart());
        }
        else if (canShake && Input.GetKeyDown(KeyCode.Space) && !isShaking)
        {
            isShaking = true;
            StartCoroutine(Restart());
        }

        if (player.transform.position.y < -15f)
        {
            canShake = true;
            restartText.gameObject.SetActive(true);
        }
    }

    private IEnumerator SpawnObjects()
    {
        while (!canShake)
        {
            GameObject newObject = Instantiate(prefab, startPosition, Quaternion.identity);
            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-moveSpeed, 0f);
            Destroy(newObject, destroyDelay);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public IEnumerator ShowScore()
    {
        audioSource.PlayOneShot(scoreSound);
        scoreText.enabled = true;
        yield return new WaitForSeconds(0.5f);
        scoreText.enabled = false;
    }

    private IEnumerator Restart()
    {
        audioSource.PlayOneShot(shakeSound);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
