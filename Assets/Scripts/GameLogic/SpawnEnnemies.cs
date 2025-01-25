using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
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

        gameCoroutine = StartCoroutine(SpawnEnnemy());
    }

    IEnumerator SpawnEnnemy()
    {
        while (true)
        {
            Object ennemyPrefab = Helpers.GetRandomObject(triangle, chargingTriangle);
            Vector3 position = Helpers.GetRandomPositionOutside(xRadius, yRadius);

            Object newEnnemy = Instantiate(ennemyPrefab, position, Quaternion.identity);
            newEnnemy.GetComponent<EnnemyCollision>().gameCoroutine = gameCoroutine;

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(spawnInterval - spawnInterval / 10, minSpawnInterval);
        }
    }
}
