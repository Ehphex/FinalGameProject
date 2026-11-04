using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawnedObject;
    public Transform spawnPoint;
    public Transform targetPoint;

    public float speed;

    public float spawnInterval = 2f; // Time interval between spawns
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObject()
    {
        if (spawnedObject != null && spawnPoint != null && targetPoint != null)
        {
            GameObject newObject = Instantiate(spawnedObject, spawnPoint.position, Quaternion.identity);
            MovingArrow movingArrow = newObject.GetComponent<MovingArrow>();

            if (movingArrow != null)
            {
                movingArrow.Initialize(targetPoint, speed);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
