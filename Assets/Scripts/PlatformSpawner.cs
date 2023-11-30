using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject gemPlatform;

    private float startAmount = 20;
    private float startCurrent = 0;
    private float spawnInterval = 0.2f;

    void Start()
    {
        InvokeRepeating("SpawnGem", 0f, Random.Range(0, 2));
        
        InvokeRepeating("SpawnPlatform", 0f, spawnInterval);
    }

    void Update()
    {
        if (startCurrent <= startAmount)
        {
            SpawnPlatform();
            startCurrent++;
        }
    }

    private void SpawnPlatform()
    {
        Instantiate(platform, transform.position, Quaternion.identity);
        transform.Translate(Random.Range(0,2), 0, Random.Range(0,2));
    }

    private void SpawnGem()
    {
        Instantiate(gemPlatform,transform.position, Quaternion.identity);
    }
}
