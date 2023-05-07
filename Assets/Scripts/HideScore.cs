using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideScore : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    private bool showScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        showScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText.enabled && showScore)
        {
            showScore = false;
            StartCoroutine(ShowScore());
        }
    }

    private IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(0.7f);
        scoreText.enabled = false;
        showScore = true;
    }
}
