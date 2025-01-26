using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    Object[] enemies;

    [SerializeField]
    int enemyByBatch;

    readonly float xRadius = 18.5f;
    readonly float yRadius = 10.5f;
    readonly float minSpawnInterval = 1.0f;
    readonly List<Object> availableEnemies = new();

    float spawnInterval;
    Coroutine gameCoroutine;

    void Start()
    {
        spawnInterval = 5.0f;
        availableEnemies.Add(enemies[0]);

        gameCoroutine = StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (
            GameData.score == availableEnemies.Count
            && availableEnemies.Count < enemies.Length
            && GameData.score != 0
        )
        {
            spawnInterval = 5.0f;
            availableEnemies.Add(enemies[GameData.score]);
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            for (int i = 0; i < enemyByBatch; i++)
            {
                Object enemyPrefab = Helpers.GetRandomObject(availableEnemies);
                Vector3 position = Helpers.GetRandomPositionOutside(xRadius, yRadius);

                GameObject newEnemy = (GameObject)Instantiate(
                    enemyPrefab,
                    position,
                    Quaternion.identity
                );
                newEnemy.tag = "Clone";
                newEnemy.GetComponent<EnemyCollision>().gameCoroutine = gameCoroutine;
            }

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(spawnInterval - spawnInterval / 10, minSpawnInterval);
        }
    }
}
