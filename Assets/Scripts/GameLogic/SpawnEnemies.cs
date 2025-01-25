using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    Object triangle;

    [SerializeField]
    Object chargingTriangle;

    readonly float xRadius = 9.5f;
    readonly float yRadius = 5.5f;
    readonly float minSpawnInterval = 0.5f;

    float spawnInterval;
    Coroutine gameCoroutine;

    void Start()
    {
        spawnInterval = 5.0f;

        gameCoroutine = StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            Object enemyPrefab = Helpers.GetRandomObject(triangle, chargingTriangle);
            Vector3 position = Helpers.GetRandomPositionOutside(xRadius, yRadius);

            GameObject newEnemy = (GameObject)Instantiate(
                enemyPrefab,
                position,
                Quaternion.identity
            );
            newEnemy.tag = "clone";
            newEnemy.GetComponent<EnemyCollision>().gameCoroutine = gameCoroutine;

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(spawnInterval - spawnInterval / 10, minSpawnInterval);
        }
    }
}
