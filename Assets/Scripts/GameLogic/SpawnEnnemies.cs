using System.Collections;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
{
    [SerializeField] Object triangle;

    readonly float xRadius = 8.9f;
    readonly float yRadius = 5.0f;
    readonly float minSpawnInterval = 0.5f;

    float spawnInterval;

    void Start()
    {
        spawnInterval = 5.0f;

        StartCoroutine(SpawnEnnemy());
    }

    IEnumerator SpawnEnnemy()
    {
        Instantiate(triangle, new Vector3(xRadius, yRadius, 0.0f), Quaternion.identity);

        yield return new WaitForSeconds(spawnInterval);

        spawnInterval = Mathf.Max(spawnInterval - spawnInterval / 10, minSpawnInterval);
    }
}
