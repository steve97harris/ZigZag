using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamonds;
    
    Vector3 lastPosition;
    public float size;
    public bool gameOver;
    
    void Start()
    {
        lastPosition = platform.transform.position;        // Get last position of platform.
        size = platform.transform.localScale.x;        // Get size of of platform with respect to x vector. 

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms",0.1f,0.2f);
    }

    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
    
    void SpawnPlatforms()
    {
        int random = Random.Range(0, 6);        // Random No between 0 and 6.
        if (random < 3)
        {
            SpawnX();
        }
        else if (random >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 position = lastPosition;        // Set 'position' vector as last position. 
        position.x += size;        // Position with respect to x is equal to position + size. 
        lastPosition = position;        // Set last position equal to new position. 
        Instantiate(platform, position, Quaternion.identity);        // Instantiate new platform at new position. 
        
        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Instantiate(diamonds, new Vector3(position.x, position.y + 1, position.z), diamonds.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 position = lastPosition;
        position.z += size;
        lastPosition = position;
        Instantiate(platform, position, Quaternion.identity);

        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Instantiate(diamonds, new Vector3(position.x, position.y + 1, position.z), diamonds.transform.rotation);
        }
    }
}
