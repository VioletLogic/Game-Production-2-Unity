using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Cultist Spawner
    [SerializeField] GameObject cultistSwarmer;
    [SerializeField ]float cultistInterval;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(cultistInterval, cultistSwarmer));
    }

    IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3f, 3), 0.2f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));

    }
}
