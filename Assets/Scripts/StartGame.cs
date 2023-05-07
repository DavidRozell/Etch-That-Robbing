using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float tiltThreshold;
    public GameObject background;
    public GameObject floor;
    public GameObject player;
    public GameObject ai;
    public TextMeshProUGUI startText;
    public AudioSource audioSource;
    public GameManager gameManager;
    public StartGame startGame;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        audioSource = gameManager.GetComponent<AudioSource>();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (acceleration.y > tiltThreshold && !gameStarted)
        {
            gameStarted = true;
            Time.timeScale = 1f;
            StartCoroutine(StartRunning());
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
            {
                gameStarted = true;
                Time.timeScale = 1f;
                StartCoroutine(StartRunning());
            }
        }
    }

    private IEnumerator StartRunning()
    {
        audioSource.PlayOneShot(gameManager.shakeSound);
        yield return new WaitForSeconds(2f);
        audioSource.Play();
        background.SetActive(true);
        floor.SetActive(true);
        gameManager.enabled = true;
        startText.enabled = false;
        startGame.enabled = false;
        player.SetActive(true);
        ai.SetActive(true);
    }

}
