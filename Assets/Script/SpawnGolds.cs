using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGolds : MonoBehaviour
{
    public GameObject Gold;
    public static Transform[] spawnPoints;
    public float spawnSec = 5;

    public float randSpawnMin = 40f;
    public float randSpawnMax = 60f;
    int rand;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        //spawnSec = Random.Range(30f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSec < 0)
        {
            rand = (int)Random.Range(0, spawnPoints.Length);
            Instantiate(Gold, spawnPoints[rand].position, spawnPoints[rand].rotation);
            rand = (int)Random.Range(0, spawnPoints.Length);
            Instantiate(Gold, spawnPoints[rand].position, spawnPoints[rand].rotation);
            rand = (int)Random.Range(0, spawnPoints.Length);
            Instantiate(Gold, spawnPoints[rand].position, spawnPoints[rand].rotation);
            spawnSec = Random.Range(randSpawnMin, randSpawnMax);
        }
        else
        {
            spawnSec -= Time.deltaTime;
        }

    }
}
