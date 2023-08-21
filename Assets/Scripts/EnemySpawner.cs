using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // spawn enemy every 5 seconds at random position on the surface around the player

        float randomX = Random.Range(-10, 10);
        float randomY = Random.Range(-10, 10);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        if (Time.time % 10 == 0)
        {
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }

    }
}
