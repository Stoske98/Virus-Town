using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProtect : MonoBehaviour
{
    public GameObject Maska;
    public static Transform[] spawnPoints;
    public float spawnSec = 60;
    public float randSpawnMin = 20f;
    public float randSpawnMax = 40f;
    int rand;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSec < 0)
        {
             rand = (int)Random.Range(0, spawnPoints.Length);
            Instantiate(Maska, spawnPoints[rand].position, spawnPoints[rand].rotation);
            spawnSec = Random.Range(randSpawnMin, randSpawnMax);
        }
        else
        {
            spawnSec -= Time.deltaTime;
        }

    }
}
