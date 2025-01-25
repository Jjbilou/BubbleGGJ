using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    Object triangle;

    [SerializeField]
    Object chargingTriangle;

    readonly float xRadius = 18.5f;
    readonly float yRadius = 10.5f;
    readonly float minSpawnInterval = 0.5f;
    readonly List<Object> availableEnemies = new();

    float spawnInterval;
    Coroutine gameCoroutine;

    void Start()
    {
        spawnInterval = 5.0f;
        availableEnemies.Add(triangle);

        gameCoroutine = StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (GameData.score >= 30 && !availableEnemies.Contains(chargingTriangle))
        {
            availableEnemies.Add(chargingTriangle);
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
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

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(spawnInterval - spawnInterval / 10, minSpawnInterval);
        }
    }
}
