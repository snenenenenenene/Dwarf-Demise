using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(5f, enemyPrefab));

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        float randomX = Random.Range(-10, 10);
        GameObject newEnemy = Instantiate(enemy, new Vector3(randomX, 0, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
