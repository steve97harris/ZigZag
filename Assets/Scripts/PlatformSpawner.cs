using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    Vector3 lastPosition;
    public float size;
    
    void Start()
    {
        lastPosition = platform.transform.position;        // Get last position of platform.
        size = platform.transform.localScale.x;        // Get size of of platform with respect to x vector. 

        for (int i = 0; i < 5; i++)
        {
            // SpawnX();
            SpawnZ();
        }
    }

    void Update()
    {
        
    }

    void SpawnX()
    {
        Vector3 position = lastPosition;        // Set 'position' vector as last position. 
        position.x += size;        // Position with respect to x is equal to position + size. 
        lastPosition = position;        // Set last position equal to new position. 
        Instantiate(platform, position, Quaternion.identity);        // Instantiate new platform at new position. 
    }

    void SpawnZ()
    {
        Vector3 position = lastPosition;
        position.z += size;
        lastPosition = position;
        Instantiate(platform, position, Quaternion.identity);
    }
}
