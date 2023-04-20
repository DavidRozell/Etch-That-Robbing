using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 startPosition;
    public GameObject prefab;
    public float moveSpeed;
    public float spawnDelay;
    public float destroyDelay;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
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
}
