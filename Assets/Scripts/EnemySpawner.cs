using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] spawnSpots;


    //Enemies array
    public GameObject[] Enemies;
    public int enemiesInArray;

    ////Spawn enemy within these positions on the map
    //private int xPos;
    //private int zPos;
    //private int yPos;

    //private int randomEnemy;

    public int enemiesCurrentCount; //Amount of enemies in game currently
    public int enemiesDesired; //Amount of enemies desired in game at the same time

    //Wait timers
    public float spawnWaitSeconds;


    void Start()
    {
        StartCoroutine(SpawnRandomEnemies());
    }

    void Update()
    {
        if (enemiesCurrentCount == 0)
        {
            StartCoroutine(SpawnRandomEnemies());
        }
    }

    //Spawn Enemies
    IEnumerator SpawnRandomEnemies()
    {
        while (enemiesCurrentCount < enemiesDesired)
        {
            //randomEnemy = Random.Range(0, enemiesInArray);
            //xPos = Random.Range(-10, 8);
            //zPos = Random.Range(17, 30);

            for (int i = 0; i < 5; i++)
            {
                Instantiate(Enemies[Random.Range(0, enemiesInArray)], spawnSpots[i]);
                enemiesCurrentCount += 1;
            }
            yield return new WaitForSeconds(0f);
        }
    }
}
