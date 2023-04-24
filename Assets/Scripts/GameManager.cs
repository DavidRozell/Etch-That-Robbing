using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector2 startPosition;
    public GameObject prefab;
    public float moveSpeed;
    public float spawnDelay;
    public float destroyDelay;
    public int score;
    public int health;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnObjects());
    }

    private void Update()
    {
        healthText.text = health.ToString();

        if (player.transform.position.y < -15f)
            SceneManager.LoadScene(0);
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
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
