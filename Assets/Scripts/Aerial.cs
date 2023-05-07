using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerial : MonoBehaviour
{
    public Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
