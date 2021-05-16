using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyRed;
    public GameObject enemy;
    public static Transform[] spawnPoints;
    public float randSpawnMin = 20f;
    public float randSpawnMax = 40f;
    public float spawnSec = 10;
    public int startSpawnEnemy = 15;
    private NavMeshAgent protivnik;
    public float timeDif = 60;
    private float startTimeDif;
    private bool redEnemy = false;
    public int sansaSpawnEnemy = 5;
    private int rand = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        startTimeDif = timeDif;
        protivnik = enemy.GetComponent<NavMeshAgent>();
        protivnik.speed = 8;
        protivnik.acceleration  =8;
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        for (int i = 0; i < startSpawnEnemy; i++)
        {
            rand = (int)Random.Range(0, spawnPoints.Length);
            spawnPoints[rand].eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            Instantiate(enemy, spawnPoints[rand].position, spawnPoints[rand].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        timeDif -= Time.deltaTime;
        dificulty();
        if (spawnSec < 0)
        {
            if(sansaSpawnEnemy != 1)
            {
                 rand = (int)Random.Range(0, spawnPoints.Length);
                //  Debug.Log(rand);
                Instantiate(enemy, spawnPoints[rand].position, spawnPoints[rand].rotation);
                spawnSec = Random.Range(randSpawnMin, randSpawnMax);
            }
               
            
           if(redEnemy == true)
            {
                rand = (int)Random.Range(0, sansaSpawnEnemy);
                
                if(rand == 0)
                {
                    rand = (int)Random.Range(0, spawnPoints.Length);
                    Instantiate(enemyRed, spawnPoints[rand].position, spawnPoints[rand].rotation);
                    spawnSec = Random.Range(randSpawnMin, randSpawnMax);
                }
               
            }
          
        }
        else
        {
            spawnSec -= Time.deltaTime;
        }
       
    }

    void dificulty()
    {
        if(timeDif < 0)
        {
            protivnik.speed +=1f;
            protivnik.acceleration +=1f;
            randSpawnMax -=5;
            randSpawnMin -= 5;
            if(randSpawnMax < 20)
            {
                
                redEnemy = true;
                sansaSpawnEnemy--;
                if(sansaSpawnEnemy<=0)
                {
                    sansaSpawnEnemy = 1;
                }
                if(randSpawnMax < 10)
                {
                    randSpawnMax = 10;
                }
            }
            if(randSpawnMin < 5)
            {
                randSpawnMin = 5;
            }
            if(protivnik.speed > 12)
            {
                protivnik.speed = 12;
            }
            if (protivnik.acceleration > 12)
            {
                protivnik.acceleration = 12;
            }
            timeDif = startTimeDif;
            return;
        }
       
       

    }
}
