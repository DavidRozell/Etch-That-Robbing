using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector2 startPosition;
    private bool canShake;
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

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnObjects());
    }

    private void Update()
    {
        healthText.text = health.ToString();

        Vector3 acceleration = Input.acceleration;
        if (canShake && acceleration.y > tiltThreshold)
        {
            SceneManager.LoadScene(0);
        }
        else if (canShake && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
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
            startPosition = new Vector2(8.19f, -0.59f);
            GameObject newObject = Instantiate(prefab, startPosition, Quaternion.identity);
            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-moveSpeed, 0f);
            Destroy(newObject, destroyDelay);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public IEnumerator ShowScore()
    {
        scoreText.enabled = true;
        yield return new WaitForSeconds(0.5f);
        scoreText.enabled = false;
    }
}
