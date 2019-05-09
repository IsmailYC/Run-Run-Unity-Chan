using UnityEngine;
using System.Collections;

public class SpawnGameObject : MonoBehaviour {
    public float minDuration, maxDuration;
    public GameObject[] prefabs;
    public float secondsToAccelerate;
    void Start()
    {
        Invoke("Spawn", 0.0f);
        Invoke("Accelerate", secondsToAccelerate);
    }

    void Spawn()
    {
        int index = Random.Range(0, prefabs.Length);
        if (prefabs[index] != null)
        {
            Instantiate(prefabs[index], transform.position, Quaternion.identity);
        }
        if(GameManager.instance.isAlive)
        {
            float secondsBetweenSpawn = minDuration;
            if (maxDuration > minDuration)
                secondsBetweenSpawn = Random.Range(minDuration, maxDuration);
            Invoke("Spawn", secondsBetweenSpawn);
        }
    }

    void Accelerate()
    {
        minDuration = minDuration / 1.1f;
        maxDuration = maxDuration / 1.1f;
        if (GameManager.instance.isAlive)
            Invoke("Accelerate", secondsToAccelerate);
    }
}
