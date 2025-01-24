using System.Collections;
using UnityEngine;
using Assets.Scripts.GameLogic;

public class SpawnEnnemies : MonoBehaviour
{
    [SerializeField] Object triangle;

    readonly float xRadius = 9.5f;
    readonly float yRadius = 5.5f;
    readonly float minSpawnInterval = 0.5f;

    float spawnInterval;

    void Start()
    {
        spawnInterval = 5.0f;

        StartCoroutine(SpawnEnnemy());
    }

    IEnumerator SpawnEnnemy()
    {
        while (true)
        {
            Vector3 position = Helpers.GetRandomPositionOutside(xRadius, yRadius);
            Instantiate(triangle, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(spawnInterval - spawnInterval / 10, minSpawnInterval);
        }
    }
}
